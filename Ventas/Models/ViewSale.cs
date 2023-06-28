namespace Ventas.Models
{
    public class ViewSale
    {
        public Product product {get; set;}

        public Sale sale { get; set;}

        public ViewSale() { }

        public ViewSale(Product product, Sale sale) { 
            
            this.product = product;
            this.sale = sale;
        }
    }
}
