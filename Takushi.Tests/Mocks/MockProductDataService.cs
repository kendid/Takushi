using System.Collections.ObjectModel;
using Takushi.App.Services;
using Takushi.DAL;
using Takushi.Model;

namespace Takushi.Tests.Mocks
{
    public class MockProductDataService : IProductDataService
    {
        private IProductRepository repository;

        public MockProductDataService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Product AddProduct()
        {
            return new Product();
        }

        public void DeleteProduct(Product product)
        {

        }

        public ObservableCollection<Product> GetAllProducts()
        {
            var observableCollection = new ObservableCollection<Product>();
            foreach (var listItem in repository.GetProducts())
                observableCollection.Add(listItem);
            return observableCollection;
        }

        public Product GetProductDetail(int productId)
        {
            Product product = repository.GetProductById(productId);
            return product;
        }

        public void UpdateProduct(Product product)
        {

        }
    }
}
