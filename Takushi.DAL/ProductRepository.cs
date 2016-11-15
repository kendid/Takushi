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
                    PurchaseDate = new DateTime(2015, 02, 28),
                    WarrantyInMonths = 24
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "Palit GeForce 750 Ti",
                    PurchaseDate = new DateTime(2014, 11, 17),
                    WarrantyInMonths = 24
                },
                new Product()
                {
                    ProductId = 3,
                    Name = "Sennheiser PC 151",
                    PurchaseDate = new DateTime(2015, 09, 26),
                    WarrantyInMonths = 36
                }
            };
        }

        public Product GetProductById(int productId)
        {
            return _products.Where(p => p.ProductId == productId).FirstOrDefault();
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

        public Product AddProduct()
        {
            var newProduct = new Product();

            _products.Add(newProduct);

            return newProduct;
        }
    }
}
