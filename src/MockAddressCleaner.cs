using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFunctions {
    
    public class MockAddressCleaner : IAddressCleaner {

        public Task<List<Address>> CleanAddressesAsync(List<Address> addresses) {

            var results = addresses.Select(a => new Address(a.ID, $"{a.Value} - PROCESSED!")).ToList();
            
            return Task.FromResult(results);
        }
    }
}