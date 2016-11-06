using System.Collections.ObjectModel;
using Takushi.Model;

namespace Takushi.App.Services
{
    public interface IProductDataService
    {
        void DeleteProduct(Product product);

        ObservableCollection<Product> GetAllProducts();

        Product GetProductDetail(int productId);

        void UpdateProduct(Product product);
    }
}