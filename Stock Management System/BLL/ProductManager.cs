using System;
using System.Collections.Generic;
using System.Data;
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
        List<Category> categoryList = new List<Category>();

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

        public List<Category> ShowCategoriesByCompanyId(int companyId)
        {
            categoryList = productGateway.GetCategoriesByCompanyId(companyId);
            return categoryList;
        }

        public List<Product> ShowProducts()
        {
            productList = productGateway.GetProducts();
            return productList;
        }

        public List<Product> ShowProductsByCompanyId(int companyId)
        {
            productList = productGateway.GetProductsByCompanyId(companyId);
            return productList;
        }

        public List<ProductViewModel> ShowProductsByCompanyandCategoryId(int companyId, int categoryId)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();

            if (!companyId.Equals(null) && companyId != 0)
            {
                if(!categoryId.Equals(null) && categoryId != 0)
                {
                    productList = productGateway.GetProductsByCompanyandCategoryId(companyId, categoryId);
                }
                else
                {
                    productList = productGateway.GetProductsByCompany(companyId);
                }
            }
            else
            {
                if (!categoryId.Equals(null) && categoryId != 0)
                {
                    productList = productGateway.GetProductsByCategoryId(categoryId);
                }
                else
                {
                    productList.Clear();
                }
            }

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

        public string StockInProduct(int productId, double stockInQuantity)
        {
            if(productId.Equals(null) || productId == 0)
            {
                return "This Item doesn't exist!";
            }
            if(stockInQuantity <= 0)
            {
               return "StockIn quantity can't be less than or equal to 0!";
            }

            int rowAffected = productGateway.StockInUpdate(productId, stockInQuantity);

            if (rowAffected > 0)
            {
                return "Stocked In Successfully!";
            }
            else
            {
                return "StockIn Failed!";
            }
        }

        public List<Product> ShowProductByProductId(int productId)
        {
            productList = productGateway.GetProductByProductId(productId);
            return productList;
        }
    }
}