﻿using System.ComponentModel;
using System.Windows.Input;
using Takushi.App.Messages;
using Takushi.App.Services;
using Takushi.App.Utility;
using Takushi.Model;

namespace Takushi.App.ViewModel
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {
        private ProductsDataService productsDataService;
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

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

        public ProductDetailViewModel()
        {
            productsDataService = new ProductsDataService();
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
            productsDataService.DeleteProduct(SelectedProduct);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveProduct(object obj)
        {
            return true;
        }

        private void SaveProduct(object product)
        {
            productsDataService.UpdateProduct(SelectedProduct);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }
    }
}