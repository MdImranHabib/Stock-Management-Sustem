using Stock_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Management_System.Models;

namespace Stock_Management_System.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ProductManager productManager = new ProductManager();
        List<Product> productList = new List<Product>();
        List<StockOut> stockOutList = new List<StockOut>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();

                btnSell.Visible = false;
                btnDamage.Visible = false;
                btnLost.Visible = false;
            }

        }

        private void BindCompany()
        {
            ddlCompany.DataSource = companyManager.ShowCompanies();
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new System.Web.UI.WebControls.ListItem(text: "Select Company", value:"0"));
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
            inputStockOutQuantity.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(ViewState["stockOuts"] == null)
            {
                ViewState["stockOuts"] = stockOutList;
            }

            stockOutList = (List<StockOut>)ViewState["stockOuts"];

            string companyName = ddlCompany.SelectedItem.Text;
            string productName = ddlItem.SelectedItem.Text;
            int productId = Convert.ToInt32(ddlItem.SelectedValue);
            double stockOutQuantity = Convert.ToDouble(inputStockOutQuantity.Value);

            StockOut stockOut = new StockOut();
            stockOut.Item = productName;
            stockOut.Company = companyName;
            stockOut.Quantity = stockOutQuantity;
            stockOut.Reason = "";
            stockOut.Date = DateTime.Now;

            stockOutList.Add(stockOut);
            ViewState["stockOuts"] = stockOutList;

            gridStockOut.DataSource = ViewState["stockOuts"];
            gridStockOut.DataBind();

            btnSell.Visible = true;
            btnDamage.Visible = true;
            btnLost.Visible = true;

        }

        protected void btnSell_Click(object sender, EventArgs e)
        {
            stockOutList = (List<StockOut>)ViewState["stockOuts"];
        }

        protected void btnDamage_Click(object sender, EventArgs e)
        {
            stockOutList = (List<StockOut>)ViewState["stockOuts"];
        }

        protected void btnLost_Click(object sender, EventArgs e)
        {
            stockOutList = (List<StockOut>)ViewState["stockOuts"];
        }

    }
}