using System.Collections.Generic;
using System.Linq;
using Takushi.DAL;
using Takushi.Model;

namespace Takushi.Tests.Mocks
{
    public class MockRepository : IProductRepository
    {
        private List<Product> products;

        public MockRepository()
        {
            products = LoadMockProducts();
        }

        private List<Product> LoadMockProducts()
        {
            return new List<Product>()
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

        public void DeleteProduct(Product product)
        {

        }

        public Product GetProductById(int productId)
        {
            return products.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {

        }
    }
}
