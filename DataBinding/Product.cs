using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;

namespace DataBinding
{
    class Product
    {
        public String ModelNumber { get; set; }
        public String ModelName { get; set; }
        public String Description { get; set; }
        public decimal UnitCost { get; set; }

        public Product() { }

        public Product(string modelNumber, string modelName, string description, decimal unitCost)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            Description = description;
            UnitCost = unitCost;
        }

        public override string? ToString()
        {
            return $"{{ModelNumber={ModelName}, ModelName={ModelName}, Description={Description}, UnitCost={UnitCost}}}";
        }

        public static List<Product> GetProducts()
        {
            int productId = 1;
            var products = new Faker<Product>()
                .RuleFor(p => p.ModelNumber, f => (productId++).ToString())
                .RuleFor(p => p.ModelName, f => f.Internet.UserName())
                .RuleFor(p => p.Description, f => f.Name.JobDescriptor())
                .RuleFor(p => p.UnitCost, f => f.Random.Decimal(0, 20))
                .Generate(50)
                .ToList();
            return products;
        }
    }

}
