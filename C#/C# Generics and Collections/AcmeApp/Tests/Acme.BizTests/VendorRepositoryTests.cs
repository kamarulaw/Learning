using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = 42;

            // Act
            var actual = repository.RetrieveValue<int>("select ...", 42);

            // Assert 
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = "test";

            // Act
            var actual = repository.RetrieveValue<string>("select ...", "test");

            // Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            // Act
            var actual = repository.RetrieveValue<Vendor>("Select...", vendor);

            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });

            // Act
            var actual = repository.Retrieve();

            // Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithKeysTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                {"ABC Corp", new Vendor(){VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com"}},
                {"XYZ Inc", new Vendor(){VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}}
            };

            // Act
            var actual = repository.RetrieveWithKeys();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                {"ABC Corp", new Vendor(){VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com"}},
                {"XYZ Inc", new Vendor(){VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}}
            };

            // Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            // Assert 
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 22, CompanyName = "Analgamated Toys", Email = "a@abc.com" });
            expected.Add(new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com" });
            expected.Add(new Vendor() { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@abc.com" });
            expected.Add(new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email = "fun@abc.com" });

            // Act 
            var vendors = repository.RetrieveAll();

            // Query Syntax
            // var vendorQuery = from v in vendors
            //                   where v.CompanyName.Contains("Toy")
            //                   select v; 

            // Method Syntax 
            // var vendorQuery = vendors.Where(FilterCompanies).OrderBy(OrderCompaniesByName);

            // Method SYntax w/ Lambda Expressions
            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toy")).OrderBy(v => v.CompanyName);

            // Assert 
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());

            // Other LINQ Methods
            // vendors.Select(v => v.Email) : shape by selecting properties
            // vendors.GroupBy(v => v.Category) : group by a defined property 
            // vendors.Average(v => v.NoOfProducts) : Aggregate elements
            // vendors.First(v => v.VendorId == 22) : Return the first matching element
            // vendors.FirstOrDefault(v => v.VendorId == 22) : Return the first matching element or null
            // vendors.Where(v=>v.CompanyName.Contains("Toy"))
            //  .GroupBy(v=>v.Category)
            //  .Select(g=>g.Sum(v=>v.NoOfProducts)) : Combine as needed
        }

        private bool FilterCompanies(Vendor v) =>
            v.CompanyName.Contains("Toy");

        private string OrderCompaniesByName(Vendor v) =>
            v.CompanyName; 
    }
}

