using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
    public class ProductService
    {
        private static string db_source = "binnsql.database.windows.net";
        private static string db_database = "binnacle";
        private static string db_user = "sqladmin";
        private static string db_password = "Pinehill30";
        private List<Product>  _products = new();

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();

            _builder.DataSource = db_source;           
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            SqlCommand cmd = new("Select ProductId, ProductName, Quantity from Products", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                Product product = new()
                {   ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                };

                _products.Add(product);
            }
            conn.Close();

            return _products;
        }
    }
}
