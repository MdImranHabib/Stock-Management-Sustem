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

        List<Product> productList = new List<Product>();
        List<Category> categoryList = new List<Category>();
        List<ProductViewModel> productViewList = new List<ProductViewModel>();

        public List<Product> GetProducts()
        {
            string query = "SELECT * FROM Products";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

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

        public List<Category> GetCategoriesByCompanyId(int companyId)
        {
            string query = @"SELECT cat.Id, cat.Name FROM Products AS pro INNER JOIN Categories AS cat ON pro.CategoryId = cat.Id WHERE CompanyId=" + companyId + "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

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

        public List<ProductViewModel> GetProductsByCompanyandCategoryId(int companyId, int categoryId)
        {
            string query = @"SELECT pro.Id, pro.Name AS Item, com.Name AS Company, cat.Name AS Category, pro.ReorderLevel, pro.Quantity FROM Products AS pro
                             INNER JOIN Companies AS com ON pro.CompanyId = com.Id
                             INNER JOIN Categories AS cat ON pro.CategoryId = cat.Id
                             WHERE CompanyId=" + companyId + "and CategoryId=" + categoryId +"";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProductViewModel product = new ProductViewModel();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Item = reader["Item"].ToString();
                product.Company = reader["Company"].ToString();
                product.Category = reader["Category"].ToString();
                product.ReorderLevel = Convert.ToDouble(reader["ReorderLevel"]);
                product.Quantity = Convert.ToDouble(reader["Quantity"]);

                productViewList.Add(product);
            }

            reader.Close();
            connection.Close();

            return productViewList;
        }

        public List<ProductViewModel> GetProductsByCategoryId(int categoryId)
        {
            string query = @"SELECT pro.Id, pro.Name AS Item, com.Name AS Company, cat.Name AS Category, pro.ReorderLevel, pro.Quantity FROM Products AS pro
                             INNER JOIN Companies AS com ON pro.CompanyId = com.Id
                             INNER JOIN Categories AS cat ON pro.CategoryId = cat.Id
                             WHERE CategoryId=" + categoryId + "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProductViewModel product = new ProductViewModel();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Item = reader["Item"].ToString();
                product.Category = reader["Category"].ToString();
                product.Company = reader["Company"].ToString();
                product.ReorderLevel = Convert.ToDouble(reader["ReorderLevel"]);
                product.Quantity = Convert.ToDouble(reader["Quantity"]);

                productViewList.Add(product);
            }

            reader.Close();
            connection.Close();

            return productViewList;
        }

        public List<ProductViewModel> GetProductsByCompany(int companyId)
        {
            string query = @"SELECT pro.Id, pro.Name AS Item, com.Name AS Company, cat.Name AS Category, pro.ReorderLevel, pro.Quantity FROM Products AS pro
                             INNER JOIN Companies AS com ON pro.CompanyId = com.Id
                             INNER JOIN Categories AS cat ON pro.CategoryId = cat.Id
                             WHERE CompanyId=" + companyId + "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProductViewModel product = new ProductViewModel();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Item = reader["Item"].ToString();
                product.Category = reader["Category"].ToString();
                product.Company = reader["Company"].ToString();
                product.ReorderLevel = Convert.ToDouble(reader["ReorderLevel"]);
                product.Quantity = Convert.ToDouble(reader["Quantity"]);

                productViewList.Add(product);
            }

            reader.Close();
            connection.Close();

            return productViewList;
        }

        public List<Product> GetProductsByCompanyId(int companyId)
        {
            string query = @"SELECT * FROM Products WHERE CompanyId="+ companyId +"";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

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

        public List<Product> GetProductByProductId(int productId)
        {
            string query = @"SELECT * FROM Products WHERE Id=" + productId + "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

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

        public int StockInUpdate(int productId, double stockInQuantity)
        {
            productList = GetProductByProductId(productId);
            int rowAffected=0;

            foreach (var product in productList)
            {
                string query = @"UPDATE Products SET Quantity=" +(product.Quantity + stockInQuantity) + "WHERE Id=" + productId + "";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                rowAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowAffected;
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