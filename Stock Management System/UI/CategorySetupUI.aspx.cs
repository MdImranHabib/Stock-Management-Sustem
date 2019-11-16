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
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {     
            BindCategory();
        }

        private void BindCategory()
        {
            gridCategory.DataSource = categoryManager.ShowCategories();
            gridCategory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = inputName.Value;

            Category category = new Category();
            category.Name = categoryName;

            lblShow.InnerText = categoryManager.Save(category);

            BindCategory();
        }

        protected void gridCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryId = gridCategory.SelectedRow.Cells[0].Text;
            string categoryName = gridCategory.SelectedRow.Cells[1].Text;

            inputName.Value = categoryName;

        }
    }
}