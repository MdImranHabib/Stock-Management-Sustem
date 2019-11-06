using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.Models;

namespace Stock_Management_System.BLL
{
    public class CategoryManager
    {
        CategoryGateway categorygateway = new CategoryGateway();

        List<Category> categoryList = new List<Category>();

        public string Save(Category category)
        {
            bool isCategoryExist = CheckName(category);

            if(category.Name.Length > 0)
            { 
                if(isCategoryExist)
                {
                    return "This Category Name is already exist! Please use another Name";
                }
                else
                {
                    int rowAffected = categorygateway.InsertCategory(category);
                
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
                return "Invalid Category Name! it can't be null.";
            }
        }

        public List<Category> ShowCategories()
        {
            categoryList = categorygateway.GetCategories();
            return categoryList;
        }

        private bool CheckName(Category category)
        {
            bool status = false;

            categoryList = categorygateway.GetCategories();

            foreach (var item in categoryList)
            {
                if (item.Name.Contains(category.Name))
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