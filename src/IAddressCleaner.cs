using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFunctions {

    public interface IAddressCleaner {

        Task<List<Address>> CleanAddressesAsync(List<Address> addresses);
    }
}