using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

using Microsoft.Extensions.Logging;

namespace MyFunctions {
    
    public class ValidateAddresses {

        private static int BATCH_SIZE = 3;

        private IAddressCleaner Cleaner { get; set; }

        public ValidateAddresses(IAddressCleaner cleaner) {

            // Save a reference to the injected Cleaner object
            this.Cleaner = cleaner;
        }

        [FunctionName("CleanAddresses")]
        public async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log
        ) {

            // Read in the data from the request
            var data = await req.Content.ReadAsAsync<List<Address>>();

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("ValidateAddresses", data);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        [FunctionName("ValidateAddresses")]
        public async Task<List<Address>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context
        ) {

            // Get the input from the context being passed in
            var allAddresses = context.GetInput<List<Address>>();

            // Break the list of address into batchs based on the config BATCH_SIZE
            var batches = Enumerable
                .Range(0, (allAddresses.Count() + BATCH_SIZE - 1) / BATCH_SIZE)
                .Select(i => allAddresses.GetRange(i * BATCH_SIZE, Math.Min(BATCH_SIZE, allAddresses.Count() - i * BATCH_SIZE)))
                .ToList();

            // For each batch, execute the Activity funtion to process them
            var tasks = batches.Select(b => context.CallActivityAsync<List<Address>>("ProcessAddressBatch", b)).ToList();

            // Wait for all the results
            var results = await Task.WhenAll(tasks);

            // Collapse all of the lists into a single list, and return
            return results.SelectMany(i => i.ToList()).ToList();
        }

        [FunctionName("ProcessAddressBatch")]
        public async Task<List<Address>> ProcessAddressBatch(
            [ActivityTrigger] List<Address> addresses,
            ILogger log
        ) {

            return await this.Cleaner.CleanAddressesAsync(addresses);
        }
    }
}