﻿using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            // colorOPtions Declaration Using Arrays
            // var colorOptions = new string[4] { "Red", "Espresso", "White", "Navy"};
            // var brownIndex = Array.IndexOf(colorOptions, "Espresso"); // static method
            // colorOptions.SetValue("Blue", 3); // instance method
            // for (int i = 0; i < colorOptions.Length; i++) // useful for iterating a subset of all elements.  allows array elemnts to be editable
            // {
            //    colorOptions[i] = colorOptions[i].ToLower();
            // }
            // foreach (var color in colorOptions) // foreach is read-only
            // {
            //   Console.WriteLine($"The color is {color}");
            // }
   
            // colorOptions Declaration Using List
            // var colorOptions = new List<string>();
            // colorOptions.Add("Espresso");
            // colorOptions.Add("White");
            // colorOptions.Add("Navy");
            // colorOptions.Insert(2, "Purple");
            // colorOptions.Remove("White");

            // colorOptions Declaration Using List w/ Collection Initializers
            var colorOptions = new List<string>() { "Red", "Espresso", "White", "Navy" };
            Console.WriteLine(colorOptions);

            // states Declaration using Dictionary
            // var states = new Dictionary<string, string>();
            // states.Add("CA", "California");
            // states.Add("WA", "Washington");
            // states.Add("NY", "New York");
            // Console.WriteLine(states);

            // states Dceclaration using Dictionary with Collection Initializers
            var states = new Dictionary<string, string>()
            {
                {"CA", "California"},
                {"WA", "Washington"},
                {"NY", "New York"},
            };
            
            Console.WriteLine(states);
        }

        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = ""; 
            if (markupPercent <= 0m)
            {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }

            var value = this.Cost + (this.Cost * markupPercent / 100);
            var operationalResult = new OperationResult<decimal>(value, message);
            return operationalResult; 
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }


}
