using System.Windows;
using Takushi.Model;

namespace Takushi.App.View
{
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
            this.DataContext = SelectedProduct;
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeProductButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedProduct.Name = "Something really old";
            SelectedProduct.PurchaseDate = "1989-09-06";
        }
    }
}
