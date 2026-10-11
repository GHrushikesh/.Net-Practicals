using Practical6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical6.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> P = new List<Product>();
            P = GetProducts();

            return View(P);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            List<Product> PALL = GetProducts();

            Product P1 = PALL.FirstOrDefault(p => p.ProductId == id);

            return View(P1);
        }
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    Description = "Lenovo Laptop",
                    Price = 55000,
                    Category = "Electronics"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Mobile",
                    Description = "Samsung Mobile",
                    Price = 25000,
                    Category = "Electronics"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Shoes",
                    Description = "Nike Shoes",
                    Price = 5000,
                    Category = "Footwear"
                }
            };
        }
    }
}