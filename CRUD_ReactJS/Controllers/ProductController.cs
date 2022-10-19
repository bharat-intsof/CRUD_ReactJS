using CRUD_ReactJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_ReactJS.Controllers
{
    public class ProductController : ApiController
    {
        AdventureWorks2017Entities db = new AdventureWorks2017Entities();
        
        [Route("api/B_product/AddProduct")]
        [HttpPost]
        public Response AddProduct(ProductModel productModel)
        {
            Response response = new Response();
            B_product product = new B_product();
            product.product_id = productModel.product_id;
            product.product_name = productModel.product_name;
            product.product_price = productModel.product_price;
            product.product_discount = productModel.product_discount;
            if (productModel.Type == "Add")
            {
                if(product != null)
                {
                    db.B_product.Add(product);
                    db.SaveChanges();
                    response.ResponseCode = "200";
                    response.ResponsMessage = "Product Added";
                }
                else
                {
                    response.ResponseCode = "100";
                    response.ResponsMessage = "Some Error Occured";
                }
            }

            if (productModel.Type == "Update")
            {
                if (product != null)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseCode = "200";
                    response.ResponsMessage = "Product Updated";
                }
                else
                {
                    response.ResponseCode = "100";
                    response.ResponsMessage = "Some Error Occured";
                }
            }

            if (productModel.Type == "Delete")
            {
                if (product != null)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    response.ResponseCode = "200";
                    response.ResponsMessage = "Product Deleted";
                }
                else
                {
                    response.ResponseCode = "100";
                    response.ResponsMessage = "Some Error Occured";
                }
            }
            return response;
        }

        [Route("api/B_product/GetProduct")]
        [HttpGet]
        public Response GetProduct()
        {
            Response response = new Response();
            List<B_product> lstProdust = new List<B_product>();
            lstProdust = db.B_product.ToList();
            response.ResponseCode = "200";
            response.ResponsMessage = "Data Fetched";
            response.lstProduct = lstProdust;

            return response;
        }

        [Route("api/B_product/ProductById")]
        [HttpPost]
        public Response ProductById(ProductModel productModel)
        {
            Response response = new Response();
            B_product product = new B_product();
            if(productModel != null && productModel.product_id > 0)
            {
                product = db.B_product.FirstOrDefault(x => x.product_id == productModel.product_id);
                response.product = product;
            }
            return response;
        }
    }
}
