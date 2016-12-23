using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Takushi.Model;

namespace Takushi.DAL
{
    public class TextFileProductRepository : IProductRepository
    {
        const string defaultFilename = "textData.txt";

        private static List<Product> _products;
        private string FilePath;

        public TextFileProductRepository(String filename)
        {
            if (_products == null)
                _products = new List<Product>();

            if (filename == null)
                filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), defaultFilename);

            FilePath = filename;
            ImportProductsFromFile(_products, FilePath);
        }

        ~TextFileProductRepository()
        {
            ExportProductsToFile(_products, FilePath);
        }

        private void ImportProductsFromFile(List<Product> products, string filename)
        {
            if (!File.Exists(filename))
            {
                FileStream fs = File.Create(filename);
                fs.Close();
            }

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                if (fields.Length >= 4)
                {
                    Product p = new Product();

                    p.ProductId = int.Parse(fields[0]);
                    p.Name = fields[1];
                    p.PurchaseDate = DateTime.Parse(fields[2]);
                    p.WarrantyInMonths = int.Parse(fields[3]);

                    products.Add(p);
                }
            }
        }

        private void ExportProductsToFile(List<Product> products, string filename)
        {
            TextWriter writer = File.CreateText(filename);

            foreach (Product p in products)
            {
                string line = "";

                line += (p.ProductId).ToString() + ";";
                line += p.Name.Replace(";", "") + ";";
                line += p.PurchaseDate.ToShortDateString() + ";";
                line += p.WarrantyInMonths.ToString() + ";";

                writer.WriteLine(line);
            }

            writer.Close();
        }

        public Product AddProduct()
        {
            Product newProduct = new Product();

            _products.Add(newProduct);

            return newProduct;
        }

        public void DeleteProduct(Product product)
        {
            _products.Remove(product);
        }

        public Product GetProductById(int productId)
        {
            return _products.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void UpdateProduct(Product product)
        {
            Product productToUpdate = GetProductById(product.ProductId);
            productToUpdate = product;
        }
    }
}
