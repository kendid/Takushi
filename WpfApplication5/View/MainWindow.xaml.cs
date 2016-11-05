using System.Windows;
using Takushi.App.Services;
using Takushi.Model;

namespace Takushi.App.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Product selectedProduct;

        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            ProductsDataService productsDataService = new ProductsDataService();
            ProductsListView.ItemsSource = productsDataService.GetAllProducts();
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
