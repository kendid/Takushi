using System.Collections.ObjectModel;
using Takushi.DAL;
using Takushi.Model;

namespace Takushi.App.Services
{
    public class ProductsDataService
    {
        ProductsRepository _repository = new ProductsRepository();

        public ObservableCollection<Product> GetAllProducts()
        {
            var observableCollection = new ObservableCollection<Product>();
            foreach (var listItem in _repository.GetProducts())
                observableCollection.Add(listItem);
            return observableCollection;
        }

        public void DeleteProduct(Product product)
        {
            _repository.DeleteProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }
    }
}
