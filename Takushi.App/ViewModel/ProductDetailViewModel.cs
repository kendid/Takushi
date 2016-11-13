using System.ComponentModel;
using System.Windows.Input;
using Takushi.App.Messages;
using Takushi.App.Services;
using Takushi.App.Utility;
using Takushi.Model;

namespace Takushi.App.ViewModel
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {
        private IProductDataService productDataService;
        private IDialogService dialogService;

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public ProductDetailViewModel(IProductDataService productDataService, IDialogService dialogService)
        {
            this.productDataService = productDataService;
            this.dialogService = dialogService;

            SaveCommand = new CustomCommand(SaveProduct, CanSaveProduct);
            DeleteCommand = new CustomCommand(DeleteProduct, CanDeleteProduct);

            Messenger.Default.Register<Product>(this, OnCoffeeReceived);
        }

        private void OnCoffeeReceived(Product product)
        {
            SelectedProduct = product;
        }

        private bool CanDeleteProduct(object obj)
        {
            return true;
        }

        private void DeleteProduct(object product)
        {
            productDataService.DeleteProduct(SelectedProduct);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveProduct(object obj)
        {
            return true;
        }

        private void SaveProduct(object product)
        {
            productDataService.UpdateProduct(SelectedProduct);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }
    }
}