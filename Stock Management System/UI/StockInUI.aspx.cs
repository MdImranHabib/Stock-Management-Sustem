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
    public partial class StockInUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ProductManager productManager = new ProductManager();
        List<Product> productList = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
            }
            ddlItem.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Item", value: "0"));
        }

        private void BindCompany()
        {
            ddlCompany.DataSource = companyManager.ShowCompanies();
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Company", value: "0"));
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            productList = productManager.ShowProductsByCompanyId(companyId);

            ddlItem.DataSource = productList;
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Item", value: "0"));
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ddlItem.SelectedValue);
            productList = productManager.ShowProductByProductId(productId);

            foreach (var product in productList)
            {
                inputReorderLevel.Value = product.ReorderLevel.ToString();
                inputAvailableQuantity.Value = product.Quantity.ToString();
            }

            inputStockInQuantity.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ddlItem.SelectedValue);
            double stockInQuantity = Convert.ToDouble(inputStockInQuantity.Value);

            lblShow.InnerText = productManager.StockInProduct(productId, stockInQuantity);
        }
    }
}