using System;
using System.Collections.Generic;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;

        public T RetrieveValue<T>(string sql, T defaultvalue)
        {
            // Use method signaure if only this method needs the type parameter.
            // Use class signature if multiple methods within the class need the type parameter

            // GENERIC CONSTRAINTS
            // where T : struct => value type
            // where T : class => reference type
            // where T : new() => type with parameterless constructor 
            // where T : Vendor => Be or derive from Vendor 
            // where T : IVendor => Be or implement the Ivendor interface 

            // Call database to retrieve the value
            // If no value is returned, return the default value
            T value = defaultvalue;
            return value;
        }
            
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        // Function below replaces RetrieveArray and RetrieveWithKeys methods
        // Since both Array and Dictionary inhereit ICollection
        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });
            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }

            foreach (var vendor in vendors)
            {
                // Console.WriteLine(vendor);
            }

            return vendors;
        }

        public IEnumerable<Vendor> RetrieveAll()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 12, CompanyName = "EFG Ltd", Email = "efg@efg.com" });
                vendors.Add(new Vendor() { VendorId = 27, CompanyName = "HIJ AG", Email = "hij@hij.com" });
                vendors.Add(new Vendor() { VendorId = 22, CompanyName = "Analgamated Toys", Email = "a@abc.com" });
                vendors.Add(new Vendor() { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@abc.com" });
                vendors.Add(new Vendor() { VendorId = 31, CompanyName = "Home Products Inc", Email = "home@abc.com" });
                vendors.Add(new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com" });
                vendors.Add(new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email = "fun@abc.com" });
            }
            return vendors;
        }

        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            this.Retrieve(); 
            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor ID: {vendor.VendorId}");
                yield return vendor; 
            }
        }

        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                {"ABC Corp", new Vendor(){VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com"}},
                {"XYZ Inc", new Vendor(){VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}}
            };

            // loop through keys to access values
            foreach (var companyName in vendors.Keys)
            {
                Console.WriteLine(vendors[companyName]);
            }

            // loop directly through values
            foreach (var value in vendors.Values)
            {
                Console.WriteLine(value);
            }

            // loop through dictionary
            foreach (var element in vendors)
            {
                var key = element.Key;
                var ven = element.Value;
                Console.WriteLine(key);
                Console.WriteLine(ven);
            }

            // Use ContainsKey or TryGetValue if youa re not sure the key is valid
            if (vendors.ContainsKey("XYZ"))
            {
                Console.WriteLine(vendors["XYZ"]);
            }

            Vendor vendor;
            if (vendors.TryGetValue("XYZ", out vendor))
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }

        public Vendor[] RetrieveArray()
        {
            var vendors = new Vendor[2]
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com"},
                new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com"}
            };
            return vendors;
        }
        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }
    }
}
