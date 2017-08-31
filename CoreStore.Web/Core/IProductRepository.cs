using System.Collections.Generic;
using CoreStore.Web.Models;

namespace CoreStore.Web.Core
{
    public interface IProductRepository
    {
        List<Product> ListProducts();
        Product GetProductById(int id);
    }
}