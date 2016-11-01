using System.Collections.Generic;
using Takushi.DAL;
using Takushi.Model;

namespace Takushi.App.Services
{
    public class ProductsDataService
    {
        ProductsRepository _repository = new ProductsRepository();

        public List<Product> GetAllProducts()
        {
            return _repository.GetProducts();
        }
    }
}