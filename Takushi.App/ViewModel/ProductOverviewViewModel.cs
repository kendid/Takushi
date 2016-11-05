using System.Collections.ObjectModel;
using System.ComponentModel;
using Takushi.App.Services;
using Takushi.Model;

namespace Takushi.App.ViewModel
{
    public class ProductOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ProductsDataService productDataService;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                RaisePropertyChanged("Products");
            }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        public ProductOverviewViewModel()
        {
            productDataService = new ProductsDataService();
            LoadData();
        }

        private void LoadData()
        {
            Products = productDataService.GetAllProducts();
        }
    }
}
