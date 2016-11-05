using System.Windows;
using Takushi.Model;

namespace Takushi.App.View
{
    /// <summary>
    /// Interaction logic for ProductDetailView.xaml
    /// </summary>
    public partial class ProductDetailView : Window
    {
        public Product SelectedProduct { get; set; }

        public ProductDetailView()
        {
            InitializeComponent();

            this.Loaded += ProductDetailView_Loaded;
        }

        void ProductDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ProductNameTextBox.Text = SelectedProduct.Name;
            PurchaseDateTextBox.Text = SelectedProduct.PurchaseDate;
            WarrantyTextBox.Text = SelectedProduct.WarrantyExpires;
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
