using System.Collections.Generic;
using System.Linq;
using CoreStore.Web.Core;
using CoreStore.Web.Models;

namespace CoreStore.Web.Infrastructure
{
    public class MemoryProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product> {
            new Product { ID = 1, Name = "Apples", Price = 1.50m },
            new Product { ID = 2, Name = "Bananas", Price = 2.00m }
        };
        public Product GetProductById(int id)
        {
            return products.Where(p => p.ID == id).FirstOrDefault();
        }

        public List<Product> ListProducts()
        {
            return products;
        }
    }
}