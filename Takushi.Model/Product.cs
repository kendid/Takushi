using System;
using System.ComponentModel;

namespace Takushi.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int productId;
        private string productName;
        private DateTime purchaseDate;
        private DateTime warrantyExpires;

        public int ProductId
        {
            get { return productId; }
            set
            {
                if (productId != value)
                {
                    productId = value;
                    RaisePropertyChanged("ProductId");
                }
            }
        }

        public string Name
        {
            get { return productName; }
            set
            {
                if (productName != value)
                {
                    productName = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set
            {
                if (purchaseDate != value)
                {
                    purchaseDate = value;
                    RaisePropertyChanged("PurchaseDate");
                }
            }
        }

        public DateTime WarrantyExpires
        {
            get { return warrantyExpires; }
            set
            {
                if (warrantyExpires != value)
                {
                    warrantyExpires = value;
                    RaisePropertyChanged("WarrantyExpires");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Product()
        {
            purchaseDate = DateTime.Today;
            warrantyExpires = purchaseDate.AddYears(2);
        }
    }
}
