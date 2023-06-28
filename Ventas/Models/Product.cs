namespace Ventas.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public int stock { get; set; }

        public Product()
        {
        }

        public Product(int idProduct, string title, string description, decimal unitPrice, int stock)
        {
            this.idProduct = idProduct;
            this.title = title;
            this.description = description;
            this.unitPrice = unitPrice;
            this.stock = stock;
        }
    }

}
