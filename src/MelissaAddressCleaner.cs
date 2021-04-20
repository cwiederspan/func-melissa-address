using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace MyFunctions {
    
    public class MelissaAddressCleaner : IAddressCleaner {

        private HttpClient Client { get; set; }

        private static string API_URL = "https://address.melissadata.net/V3/WEB/GlobalAddress/doGlobalAddress";

        private static string API_KEY = Environment.GetEnvironmentVariable("MELISSA_DAT_API_KEY");

        public MelissaAddressCleaner(
            HttpClient client
        ) {
            this.Client = client;
            
            this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Address>> CleanAddressesAsync(List<Address> addresses) {

            var requestData = new MelissaDataRequest() {
                CustomerID = API_KEY
            };

            requestData.Records = addresses.Select(a => new MelissaDataAddress {
                RecordID = a.ID,
                AddressLine1 = a.Value,
                Country = a.Country
            }).ToList();

            //var requestJson = JsonSerializer.Serialize(requestData);

            var result = await this.Client.PostAsJsonAsync(API_URL, requestData);

            // var responseJson = await result.Content.ReadAsStringAsync();

            var resultData = await result.Content.ReadAsAsync<MelissaDataResponse>();

            var newAddresses = resultData.Records.Select(r => new Address(r.RecordID, r.FormattedAddress)).ToList();

            return newAddresses;
        }
    }
}