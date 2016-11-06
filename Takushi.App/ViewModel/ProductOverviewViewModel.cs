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
        public event PropertyChangedEventHandler PropertyChanged;
        private IProductDataService productDataService;
        private IDialogService dialogService;

        public ICommand EditCommand { get; set; }

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

        private void LoadData()
        {
            Products = productDataService.GetAllProducts();
        }
    }
}
