using System;
using System.ComponentModel;

namespace Takushi.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int productId;
        private string productName;
        private Warranty warranty;

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
            get { return warranty.StartDate; }
            set
            {
                if (warranty.StartDate != value)
                {
                    warranty.StartDate = value;
                    RaisePropertyChanged("PurchaseDate");
                }
            }
        }

        public int WarrantyInMonths
        {
            get { return warranty.WarrantyInMonths; }
            set
            {
                if (warranty.WarrantyInMonths != value)
                {
                    warranty.WarrantyInMonths = value;
                    RaisePropertyChanged("WarrantyInMonths");
                }
            }
        }

        public DateTime WarrantyExpirationDate
        {
            get
            {
                return warranty.StartDate.AddMonths(warranty.WarrantyInMonths);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Product()
        {
            warranty = new Warranty(DateTime.Today, 24);
        }
    }
}
