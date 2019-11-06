using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Stock_Management_System.Models;

namespace Stock_Management_System.DAL
{
    public class ProductGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDB"].ConnectionString;

        public List<Product> GetProducts()
        {
            string query = "SELECT * FROM Products";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productList = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                product.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                product.ReorderLevel = Convert.ToDouble(reader["ReorderLevel"]);
                product.Quantity = Convert.ToDouble(reader["Quantity"]);

                productList.Add(product);
            }

            reader.Close();
            connection.Close();

            return productList;
        }

        public int InsertProduct(Product product)
        {
            string query = "INSERT INTO Products VALUES(@Name, @CategoryId, @CompanyId, @ReorderLevel, @Quantity)";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("Name", SqlDbType.NVarChar);
            command.Parameters["Name"].Value = product.Name;

            command.Parameters.Add("CategoryId", SqlDbType.Int);
            command.Parameters["CategoryId"].Value = product.CategoryId;

            command.Parameters.Add("CompanyId", SqlDbType.Int);
            command.Parameters["CompanyId"].Value = product.CompanyId;

            command.Parameters.Add("ReorderLevel", SqlDbType.Float);
            command.Parameters["ReorderLevel"].Value = product.ReorderLevel;

            command.Parameters.Add("Quantity", SqlDbType.Float);
            command.Parameters["Quantity"].Value = product.Quantity;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}