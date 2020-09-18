using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWebAPI.Models;
using ProductWebAPI.Interfaces;

namespace ProductWebAPI.Repositories
{
    public class ProductRepo : IProductRepo
    {

        private readonly AppDbContext _db;

        public ProductRepo(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            List<Product> listResult;
            listResult = _db.products.ToList<Product>();

            return listResult;

        }

        public Product GetProduct(int id)
        {

            Product product = new Product();
            product = _db.products.FirstOrDefault<Product>(x => x.productID == id);

            return product;

        }

        public Product InsertProduct(Product product)
        {

            _db.products.Add(product);
            _db.SaveChanges();

            return product;

        }

        public Product UpdateProduct(Product productWithChanges)
        {

            Product product = _db.products.FirstOrDefault(x => x.productID == productWithChanges.productID);
            if (product != null)
            {

                // product.productID = productWithChanges.productID;
                product.productName = productWithChanges.productName;
                product.serving = productWithChanges.serving;
                product.package = productWithChanges.package;
                product.prices = productWithChanges.prices;
                product.qty = productWithChanges.qty;

                _db.products.Update(product);
                _db.SaveChanges();

            }

            return product;

        }

        public Product DeleteProduct(int id)
        {

            Product product = new Product();
            product = _db.products.FirstOrDefault<Product>(x => x.productID == id);

            if (product != null)
            {

                _db.products.Remove(product);
                _db.SaveChanges();

            }

            return product;

        }

        IEnumerable<Product> IProductRepo.GetProducts()
        {
            throw new NotImplementedException();
        }

        Product IProductRepo.GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        Product IProductRepo.InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Product IProductRepo.UpdateProduct(Product ProductwithChanges)
        {
            throw new NotImplementedException();
        }

        Product IProductRepo.DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}