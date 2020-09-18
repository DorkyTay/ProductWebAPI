using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWebAPI.Models;

namespace ProductWebAPI.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);

        Product InsertProduct(Product product);

        Product UpdateProduct(Product ProductwithChanges);

        Product DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
    }
}

