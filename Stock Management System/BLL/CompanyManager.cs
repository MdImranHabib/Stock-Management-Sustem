using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.Models;

namespace Stock_Management_System.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();

        List<Company> companyList = new List<Company>();

        public string Save(Company company)
        {
            bool isCompanyExist = CheckName(company);

            if (company.Name.Length > 0)
            {
                if (isCompanyExist)
                {
                    return "This Company Name is already exist! Please use another Name";
                }
                else
                {
                    int rowAffected = companyGateway.InsertCompany(company);

                    if (rowAffected > 0)
                    {
                        return "Saved Successfully!";
                    }
                    else
                    {
                        return "Save Failed!";
                    }
                }
            }
            else
            {
                return "Invalid Company Name! it can't be null.";
            }
        }

        public List<Company> ShowCompanies()
        {
            companyList = companyGateway.GetCompanies();
            return companyList;
        }

        private bool CheckName(Company company)
        {
            bool status = false;

            companyList = companyGateway.GetCompanies();

            foreach (var item in companyList)
            {
                if (item.Name.Contains(company.Name))
                {
                    status = true;
                    break;
                }
                else
                {
                    status = false;
                }
            }

            return status;
        }
    }
}