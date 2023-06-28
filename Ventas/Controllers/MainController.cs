using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Ventas.DBConexion;
using Ventas.Models;

namespace Ventas.Controllers
{
    [ApiController]
    [Route("api/[controlller]")]
    public class MainController : Controller
    {

        [HttpGet("/titles")]
        public async Task<List<string>> titles()
        {

            Conexion con = new Conexion();

            List<string> titles = new List<string>();

            SqlConnection connection = con.getConnection();

            connection.Open();

            string query = $"SELECT titulo FROM Productos";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string title = (string)reader["Titulo"];

                titles.Add(title);
            }

            return titles;
        }

        [HttpGet("/salesByProduct/{product}")]
        public async Task<List<SalesByProduct>> saludar(string product)
        {
            Conexion con = new Conexion();

            List<SalesByProduct> listSales = new List<SalesByProduct>();

            SqlConnection connection = con.getConnection();

            connection.Open();

            string query = $"SELECT * FROM salesByProduct WHERE Titulo = '{product}'";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string title = (string)reader["Titulo"];
                string description = (string)reader["Descripcion"];
                decimal unitPrice = (decimal)reader["PrecioUnitario"];
                int quantity = (int)reader["CantidadVendida"];
                DateTime date = (DateTime)reader["Fecha"];

                SalesByProduct sale = new SalesByProduct(title, description, unitPrice, quantity, date);

                listSales.Add(sale);
            }

            connection.Close();

            return listSales;
        }

        [HttpGet("/allSales")]
        public async Task<List<ViewSale>> allSales()
        {

            List<ViewSale> viewSaleList = new List<ViewSale>();

            Conexion con = new Conexion();

            SqlConnection connection = con.getConnection();

            connection.Open();

            string query = "SELECT * FROM VistaVentas";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int idProduct = (int)reader["IDProductos"];
                string title = (string)reader["Titulo"];
                string description = (string)reader["Descripcion"];
                decimal unitPrice = (decimal)reader["PrecioUnitario"];
                int stock = (int)reader["Existencias"];

                Product product = new Product(idProduct, title, description, unitPrice, stock);

                int idSales = (int)reader["IDVentas"];
                int idProductx = (int)reader["IDProductos"];
                int quantitySold = (int)reader["CantidadVendida"];
                DateTime date = (DateTime)reader["Fecha"];


                Sale sale = new Sale(idSales, idProductx, quantitySold, date);

                ViewSale viewSale = new ViewSale();

                viewSale.sale = sale;
                viewSale.product = product;

                viewSaleList.Add(viewSale);
            }

            connection.Close();

            return viewSaleList;
        }

        [HttpGet("/bestSelling")]
        public async Task<List<ViewSale>> bestSelling()
        {

            List<ViewSale> viewBestSellingList = new List<ViewSale>();

            Conexion con = new Conexion();

            SqlConnection connection = con.getConnection();

            connection.Open();

            string query = "SELECT TOP (2) * FROM VistaVentas ORDER BY CantidadVendida DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int idProduct = (int)reader["IDProductos"];
                string title = (string)reader["Titulo"];
                string description = (string)reader["Descripcion"];
                decimal unitPrice = (decimal)reader["PrecioUnitario"];
                int stock = (int)reader["Existencias"];

                Product product = new Product(idProduct, title, description, unitPrice, stock);

                int idSales = (int)reader["IDVentas"];
                int idProductx = (int)reader["IDProductos"];
                int quantitySold = (int)reader["CantidadVendida"];
                DateTime date = (DateTime)reader["Fecha"];


                Sale sale = new Sale(idSales, idProductx, quantitySold, date);

                ViewSale viewSale = new ViewSale();

                viewSale.sale = sale;
                viewSale.product = product;

                viewBestSellingList.Add(viewSale);
            }

            return viewBestSellingList;
        }

        [HttpGet("/allProducts")]
        public async Task<List<Product>> getAllProducts()
        {

            List<Product> allProductsList = new List<Product>();

            Conexion con = new Conexion();

            SqlConnection connection = con.getConnection();

            connection.Open();

            string query = "SELECT * FROM Productos";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int idProduct = (int)reader["IDProductos"];
                string title = (string)reader["Titulo"];
                string description = (string)reader["Descripcion"];
                decimal unitPrice = (decimal)reader["PrecioUnitario"];
                int stock = (int)reader["Existencias"];

                Product product = new Product(idProduct, title, description, unitPrice, stock);

                allProductsList.Add(product);
            }

            return allProductsList;

        }
    }

}
