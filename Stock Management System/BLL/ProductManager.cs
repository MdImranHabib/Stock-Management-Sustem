using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.Models;

namespace Stock_Management_System.BLL
{
    public class ProductManager
    {
        ProductGateway productGateway = new ProductGateway();

        List<Product> productList = new List<Product>();

        public string Save(Product product)
        {
            bool isProductExist = CheckProduct(product);

            if (product.Name.Length > 0)
            {
                if (isProductExist)
                {
                    return "This item Name is already exist! Please use another Name";
                }
                else
                {
                    int rowAffected = productGateway.InsertProduct(product);

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

        public List<Product> ShowProducts()
        {
            productList = productGateway.GetProducts();
            return productList;
        }

        private bool CheckProduct(Product product)
        {
            bool status = false;

            productList = productGateway.GetProducts();

            foreach (var item in productList)
            {
                if ((item.CategoryId == product.CategoryId) && (item.CompanyId == product.CompanyId) && (item.Name.Contains(product.Name)))
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