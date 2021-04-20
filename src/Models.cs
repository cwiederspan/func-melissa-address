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
            this.Country = "US";
        }
        
        public string ID { get; set; }

        public string Value { get; set; }

        public string Country { get; set; }
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

    public class MelissaDataResponse {

        public MelissaDataResponse() {
            this.Records = new List<MelissaDataResponseAddress>();
        }

        public string Version { get; set; }

        public string TransmissionReference { get; set; }

        public string TransmissionResult { get; set; }

        public int TotalRecords { get; set; }

        // Options???

        public List<MelissaDataResponseAddress> Records { get; set; }
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

    public class MelissaDataResponseAddress: MelissaDataAddress {

        public string Results { get; set; }
        public string FormattedAddress { get; set; }
        public string AddressType { get; set; }
        public string AddressKey { get; set; }
        public string CountryName { get; set; }
        public string CountryISO3166_1_Alpha2 { get; set; }
        public string CountryISO3166_1_Alpha3 { get; set; }
        public string CountryISO3166_1_Numeric { get; set; }
        public string CountrySubdivisionCode { get; set; }
        public string Thoroughfare { get; set; }
        public string ThoroughfarePreDirection { get; set; }
        public string ThoroughfareLeadingType { get; set; }
        public string ThoroughfareName { get; set; }
        public string ThoroughfareTrailingType { get; set; }
        public string ThoroughfarePostDirection { get; set; }
        public string DependentThoroughfare { get; set; }
        public string DependentThoroughfarePreDirection { get; set; }
        public string DependentThoroughfareLeadingType { get; set; }
        public string DependentThoroughfareName { get; set; }
        public string DependentThoroughfareTrailingType { get; set; }
        public string DependentThoroughfarePostDirection { get; set; }
        public string Building { get; set; }
        public string PremisesType { get; set; }
        public string PremisesNumber { get; set; }
        public string SubPremisesType { get; set; }
        public string SubPremisesNumber { get; set; }
        public string PostBox { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}