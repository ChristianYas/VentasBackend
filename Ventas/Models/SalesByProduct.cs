namespace Ventas.Models
{
    public class SalesByProduct
    {
        public string title { get; set; }

        public string description { get; set;}

        public decimal unitPrice { get; set;}

        public int quantity { get; set;}

        public DateTime date { get; set;}

        public SalesByProduct() { }

        public SalesByProduct(string title, string description, decimal unitPrice, int quantity, DateTime date)
        {
            this.title = title;
            this.description = description;
            this.unitPrice = unitPrice;
            this.date = date;
            this.quantity = quantity;
        }
    }
}
