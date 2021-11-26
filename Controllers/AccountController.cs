using Ecommerce_SDA.Models.User;
using Microsoft.AspNetCore.Mvc;
using SDA_Ecommerce.Models.Account;
using SDA_Ecommerce.Models.ApiResponse;
using SDA_Ecommerce.Service;
using System;

namespace SDA_Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServices _services;
        public AccountController(IServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _services.Login(model).Result;
                    if (result == "1")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login Attemp, Your Email or Password not Correct!");
                    }
                }
                catch (Exception ex)
                {

                    var error = ex.Message;
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var Result = _services.SignUp(model).Result;
                    if (Result.Succeeded)
                    {
                        ViewBag.Message = string.Format("Account Created Successfully, Please Login Now!");
                        return View();
                    }
                    else
                    {
                        foreach (var error in Result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {

                    var error = ex.Message;
                    ModelState.AddModelError("", error);
                }


            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            var result = _services.Logout().Result;

            return RedirectToAction("Index", "Home");
        }
    }
}
