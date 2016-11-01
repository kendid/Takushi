using System.Windows;
using Takushi.App.Services;

namespace Takushi.App.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
