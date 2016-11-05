using System.ComponentModel;

namespace Takushi.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int productId;
        private string productName;
        private string purchaseDate;
        private string warrantyExpires;

        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                RaisePropertyChanged("ProductId");
            }
        }

        public string Name
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                RaisePropertyChanged("Name");
            }
        }

        public string PurchaseDate
        {
            get
            {
                return purchaseDate;
            }
            set
            {
                purchaseDate = value;
                RaisePropertyChanged("PurchaseDate");
            }
        }

        public string WarrantyExpires
        {
            get
            {
                return warrantyExpires;
            }
            set
            {
                warrantyExpires = value;
                RaisePropertyChanged("WarrantyExpires");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
