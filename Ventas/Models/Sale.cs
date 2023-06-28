namespace Ventas.Models
{
    public class Sale
    {
        public int idSale { get; set; }
        public int idProduct { get; set; }
        public int quantitySold { get; set; }
        public DateTime date { get; set; }

        public Sale()
        {
        }

        public Sale(int idSale, int idProduct, int quantitySold, DateTime date)
        {
            this.idSale = idSale;
            this.idProduct = idProduct;
            this.quantitySold = quantitySold;
            this.date = date;
        }
    }

}
