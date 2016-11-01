namespace Takushi.Model
{
    public class Product
    {
        public string Name { get; set; }
        public string PurchaseDate { get; set; }
        public string WarrantyExpires { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
