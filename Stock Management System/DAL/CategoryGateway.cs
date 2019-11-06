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
    public class CategoryGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDB"].ConnectionString;

        public List<Category> GetCategories()
        {
            string query = "SELECT * FROM Categories";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Category> categoryList = new List<Category>();

            while (reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.Name = reader["Name"].ToString();

                categoryList.Add(category);
            }

            reader.Close();
            connection.Close();

            return categoryList;
        }

        public int InsertCategory(Category category)
        {
            string query = "INSERT INTO Categories VALUES(@Name)";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("Name", SqlDbType.NVarChar);
            command.Parameters["Name"].Value = category.Name;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}