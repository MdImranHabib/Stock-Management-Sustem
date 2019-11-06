using Stock_Management_System.BLL;
using Stock_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Management_System.UI
{
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindCompany();
        }

        private void BindCompany()
        {
            gridCompany.DataSource = companyManager.ShowCompanies();
            gridCompany.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string companyName = inputName.Value;

            Company company = new Company();
            company.Name = companyName;

            lblShow.InnerText = companyManager.Save(company);

            BindCompany();
        }
    }
}