using Microsoft.AspNetCore.Mvc;
using SDA_Ecommerce.Models;
using SDA_Ecommerce.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDA_Ecommerce.Controllers
{
    public class LaptopController : Controller
    {
        private readonly IServices _services;

        public LaptopController(IServices services)
        {
            _services = services;
        }
        public IActionResult LapProducts()
        {
            IEnumerable<ProductDetails> ObjectList = _services.GetAllLaptopProducts();



            return View("LapProducts", ObjectList);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDetails product)
        {
            product.CreatedDate = DateTime.Now.ToShortDateString();
            product.Category = "Laptop";
            try
            {
                var result = _services.AddProduct(product).Result;
                if (result == "1")
                {
                    return RedirectToAction("LapProducts");
                }
                else
                {
                    ModelState.AddModelError("", "Adding Failed Please Try Again");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);

            }

            return View(product);
        }

        [HttpGet]
        public IActionResult GetProductDetails (int id)
        {
            try
            {
                var product = _services.GetProductDetails(id);
                if (product != null)
                {
                    ViewBag.Product = product;
                    return View();
                }
            }
            catch (Exception ex)
            {

                return View(ex);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            try
            {
                var product = _services.GetProductDetails(id);
                if (product != null)
                {
                    ViewBag.Product = product;
                    return View();
                }
            }
            catch (Exception ex)
            {

                return View(ex);
            }
            return View();
        }



    }
}

