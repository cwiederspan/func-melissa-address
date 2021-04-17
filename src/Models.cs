using System;
using System.Collections.Generic;

namespace MyFunctions {

    public class Address {

        public Address() {
            // Nothing to do here
        }

        public Address(string id, string value) {
            this.ID = id;
            this.Value = value;
        }
        
        public string ID { get; set; }

        public string Value { get; set; }
    }

    public class MelissaDataRequest {

        public MelissaDataRequest() {
            this.Records = new List<MelissaDataAddress>();
        }

        public string TransmissionReference { get; set; }

        public string CustomerID { get; set; }

        // Options???

        public List<MelissaDataAddress> Records { get; set; }
    }

    public class MelissaDataAddress {

        public string RecordID { get; set; }

        public string Organization { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string AddressLine5 { get; set; }

        public string AddressLine6 { get; set; }

        public string AddressLine7 { get; set; }
        
        public string AddressLine8 { get; set; }

        public string DoubleDependentLocality { get; set; }

        public string DependentLocality { get; set; }

        public string Locality { get; set; }

        public string SubAdministrativeArea { get; set; }

        public string AdministrativeArea { get; set; }

        public string PostalCode { get; set; }

        public string SubNationalArea { get; set; }

        public string Country { get; set; }
    }
}