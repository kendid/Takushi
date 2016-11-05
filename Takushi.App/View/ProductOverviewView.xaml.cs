using System.Collections.ObjectModel;
using System.Windows;
using Takushi.App.Services;
using Takushi.Model;

namespace Takushi.App.View
{
    public partial class ProductOverviewView : Window
    {
        private Product selectedProduct;
        private ObservableCollection<Product> Products;

        public ProductOverviewView()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            ProductsDataService productsDataService = new ProductsDataService();
            Products = productsDataService.GetAllProducts();
            ProductsListView.ItemsSource = Products;
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

        private void AddFakeProductButton_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                Name = "Test product",
                PurchaseDate = "2000-01-01",
                WarrantyExpires = "2005-12-31"
            };

            Products.Add(product);
        }
    }
}
