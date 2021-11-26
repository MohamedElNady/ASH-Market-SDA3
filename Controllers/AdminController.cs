using Ecommerce_SDA.Models;
using Microsoft.AspNetCore.Mvc;
using SDA_Ecommerce.Models;
using SDA_Ecommerce.Models.ApiResponse;
using SDA_Ecommerce.Service;
using System;

namespace SDA_Ecommerce.Controllers
{
	public class AdminController : Controller
	{
		private readonly IServices _services;
		public AdminController(IServices services)
		{
			_services = services;
		}
		public ActionResult AddProduct()
		{
			return View();
		}
        public ActionResult EditProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeletedItem(int id)
        {
            try
            {
                var product = _services.DeletedItem(id);
                if (product != null)
                {
                    ViewBag.Product = product;
                    return RedirectToAction("LapProducts", "Laptop");
                }
            }
            catch (Exception ex)
            {

                return View(ex);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditItem(int id)
        {
			try
			{
                var product = _services.GetProductDetails(id);
                return View("EditProduct", product);
            }
			catch (Exception)
			{

                return RedirectToAction("LapProducts", "Laptop");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult EditItem(ProductDetails model)
        {
            try
            {
                var product = _services.EditItemData(model);
                return RedirectToAction("LapProducts", "Laptop");
            }
            catch (Exception)
            {

                return RedirectToAction("LapProducts", "Laptop");
            }

        }
    }
		
}
