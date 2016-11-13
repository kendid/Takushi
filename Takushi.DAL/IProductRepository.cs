using System.Collections.Generic;
using Takushi.Model;

namespace Takushi.DAL
{
    public interface IProductRepository
    {
        void DeleteProduct(Product product);

        Product GetProductById(int productId);

        List<Product> GetProducts();

        void UpdateProduct(Product product);

        Product AddProduct();
    }
}