using System.Collections.Generic;
using System.Windows;
using Takushi.App.Services;
using Takushi.Model;

namespace Takushi.App.View
{
    public partial class ProductOverviewView : Window
    {
        private Product selectedProduct;
        private List<Product> products;

        public ProductOverviewView()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            ProductsDataService productsDataService = new ProductsDataService();
            products = productsDataService.GetAllProducts();
            ProductsListView.ItemsSource = products;
        }

        private void ProductsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedProduct = e.AddedItems[0] as Product;

            if (e != null)
            {
                ProductNameLabel.Content = selectedProduct.Name;
                PurchaseDateLabel.Content = selectedProduct.PurchaseDate;
                WarrantyLabel.Content = selectedProduct.WarrantyExpires;
            }
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            ProductDetailView productDetailView = new ProductDetailView();
            productDetailView.SelectedProduct = selectedProduct;
            productDetailView.ShowDialog();
        }
    }
}
