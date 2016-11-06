using System;
using System.Collections.Generic;
using System.Linq;
using Takushi.Model;

namespace Takushi.DAL
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;

        public List<Product> GetProducts()
        {
            if (_products == null)
                LoadExampleProducts();
            return _products;
        }

        private void LoadExampleProducts()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "TOSHIBA Notebook",
                    PurchaseDate = "2015-02-28",
                    WarrantyExpires = "2017-02-28"
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "Palit GeForce 750 Ti",
                    PurchaseDate = "2014-11-17",
                    WarrantyExpires = "2016-11-17"
                },
                new Product()
                {
                    ProductId = 3,
                    Name = "Sennheiser PC 151",
                    PurchaseDate = "2015-09-26",
                    WarrantyExpires = "2018-09-26"
                }
            };
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            Product productToUpdate = _products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            productToUpdate = product;
        }

        public void DeleteProduct(Product product)
        {
            _products.Remove(product);
        }
    }
}
