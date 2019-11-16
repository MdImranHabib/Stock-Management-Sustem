using Stock_Management_System.BLL;
using Stock_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Management_System.UI
{
    public partial class SearchandViewUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        CategoryManager categoryManager = new CategoryManager();
        ProductManager productManager = new ProductManager();
        List<Category> categoryList = new List<Category>();
        List<ProductViewModel> productList = new List<ProductViewModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
                BindCategory();
            }
        }

        private void BindCompany()
        {
            ddlCompany.DataSource = companyManager.ShowCompanies();
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Company", value: "0"));
        }

        private void BindCategory()
        {
            ddlCategory.DataSource = categoryManager.ShowCategories();
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Category", value: "0"));
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            categoryList = productManager.ShowCategoriesByCompanyId(companyId);

            ddlCategory.DataSource = categoryList;
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Item", value: "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);

            productList = productManager.ShowProductsByCompanyandCategoryId(companyId, categoryId);

            gridSearchandViewItems.DataSource = productList;
            gridSearchandViewItems.DataBind();
        }
    }
}