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
    public class CompanyGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDB"].ConnectionString;

        public List<Company> GetCompanies()
        {
            string query = "SELECT * FROM Companies";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Company> companyList = new List<Company>();

            while (reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.Name = reader["Name"].ToString();

                companyList.Add(company);
            }

            reader.Close();
            connection.Close();

            return companyList;
        }

        public int InsertCompany(Company company)
        {
            string query = "INSERT INTO Companies VALUES(@Name)";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("Name", SqlDbType.NVarChar);
            command.Parameters["Name"].Value = company.Name;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}