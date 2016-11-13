using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Takushi.App.Messages;
using Takushi.App.Services;
using Takushi.App.Utility;
using Takushi.Model;

namespace Takushi.App.ViewModel
{
    public class ProductOverviewViewModel : INotifyPropertyChanged
    {
        private IProductDataService productDataService;
        private IDialogService dialogService;

        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                if (products != value)
                {
                    products = value;
                    NotifyPropertyChanged("Products");
                }
            }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;
                    NotifyPropertyChanged("SelectedProduct");
                }
            }
        }

        public ProductOverviewViewModel(IProductDataService productDataService, IDialogService dialogService)
        {
            this.productDataService = productDataService;
            this.dialogService = dialogService;

            LoadData();

            LoadCommands();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            dialogService.CloseDetailDialog();
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditProduct, CanEditProduct);
            AddCommand = new CustomCommand(AddProduct, CanAddProduct);
        }

        private void EditProduct(object obj)
        {
            Messenger.Default.Send<Product>(selectedProduct);

            dialogService.ShowDetailDialog();
        }

        private bool CanEditProduct(object obj)
        {
            return (SelectedProduct != null);
        }

        private void AddProduct(object obj)
        {
            var newProduct = productDataService.AddProduct();

            Messenger.Default.Send<Product>(newProduct);

            dialogService.ShowDetailDialog();
        }

        private bool CanAddProduct(object obj)
        {
            return true;
        }

        private void LoadData()
        {
            Products = productDataService.GetAllProducts();
        }
    }
}
