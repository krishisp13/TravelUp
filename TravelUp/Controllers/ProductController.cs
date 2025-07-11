using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelUp.Models;

namespace TravelUp.Controllers
{
    public class ProductController : Controller
    {

        private static List<Product> _products = new List<Product>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _products.Count + 1;
                _products.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public PartialViewResult ItemList()
        {
            return PartialView("_ItemList", _products);
        }

        [HttpPost]
        public JsonResult AddProductAjax(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Category) || product.Amount <= 0)
            {
                return Json(new { success = false, message = "Please fill all required fields." });
            }

            product.Id = _products.Count + 1;
            _products.Add(product);

            return Json(new { success = true });
        }

    }
}