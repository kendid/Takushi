using System;

namespace Takushi.Model
{
    public class Warranty
    {
        private int warrantyInMonths;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WarrantyInMonths
        {
            get
            {
                return warrantyInMonths;
            }
            set
            {
                if ((warrantyInMonths != value) && (value > 0))
                {
                    EndDate = StartDate.AddMonths(value);
                    warrantyInMonths = value;
                }
            }
        }

        public Warranty(DateTime startDate)
        {
            StartDate = startDate;
            EndDate = startDate.AddMonths(1);
            WarrantyInMonths = 1;
        }

        public Warranty(DateTime startDate, DateTime endDate) : this(startDate)
        {
            EndDate = endDate;
        }

        public Warranty(DateTime startDate, int warrantyInMonths) : this(startDate)
        {
            WarrantyInMonths = warrantyInMonths;
        }
    }
}