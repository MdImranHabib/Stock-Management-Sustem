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
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        ProductManager productManager = new ProductManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCategory();
                BindCompany();
            }
        }

        private void BindCategory()
        {
            ddlCategory.DataSource = categoryManager.ShowCategories();
            ddlCategory.DataBind();
        }

        private void BindCompany()
        {
            ddlCompany.DataSource = companyManager.ShowCompanies();
            ddlCompany.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            string itemName = inputName.Value;
            double reorderLevel = Convert.ToDouble(inputReorderLevel.Value);

            Product product = new Product();
            product.Name = itemName;
            product.CategoryId = categoryId;
            product.CompanyId = companyId;
            product.ReorderLevel = reorderLevel;
            product.Quantity = 0.0;

            lblShow.InnerText = productManager.Save(product);

        }
    }
}