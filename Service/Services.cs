using Ecommerce_SDA.Data;
using Ecommerce_SDA.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SDA_Ecommerce.Models;
using SDA_Ecommerce.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SDA_Ecommerce.Service
{
    public class Services : IServices
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        public Services(ApplicationDbContext db, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager)
        {
            _db = db;
            _signInManager = signInManager;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }

        public async Task<string> AddProduct(ProductDetails product)
        {

            var Add = _db.ProductDetails.AddAsync(product).Result;
            if (Add.State == EntityState.Added)
            {
                _db.SaveChanges();
                return "1";
            }
            return "0";
        }

        public async Task<string> DeletedItem(int id)
        {
            var product = GetProductDetails(id);

            if (product != null)
            {
                _db.ProductDetails.Remove(product);
                await _db.SaveChangesAsync();
                return "1";
            }
            return "0";
        }

        public async Task<string> EditItemData(ProductDetails model)
        {

            model.CreatedDate = DateTime.Now.ToShortDateString();
            model.Category = "Laptop";
            _db.ProductDetails.Update(model);
            await _db.SaveChangesAsync();
            return "1";

        }

        public IEnumerable<ProductDetails> GetAllLaptopProducts()
        {
            var products = (from product in _db.ProductDetails
                           .Where(x => x.Category == "Laptop")
                            select new ProductDetails
                            {
                                Brand = product.Brand,
                                Description = product.Description,
                                Category = product.Category,
                                Image = product.Image,
                                Name = product.Name,
                                Price = product.Price,
                                ProductId = product.ProductId,
                                CreatedDate = product.CreatedDate
                            }).ToList();
            //var x = _db.ProductDetails;
            //return x;
            return products;
        }

        public ProductDetails GetProductDetails(int id)
        {
            var product = _db.ProductDetails.FirstOrDefaultAsync(x => x.ProductId == id).Result;
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public async Task<string> Login(LoginVM model)
        {
            var user = _UserManager.FindByEmailAsync(model.Email).Result;
            if (user != null && await _UserManager.CheckPasswordAsync(user, model.Password))
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return "1";
                }
            }
            return "0";

        }

        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            return "1";

        }

        public async Task<IdentityResult> SignUp(SignUpVM model)
        {
            ApplicationUser user = new();
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.FName = model.FName;
            user.LName = model.LName;
            user.Address = model.Address;
            var Result = await _UserManager.CreateAsync(user, model.Password);
            if (Result.Succeeded)
            {
                await _UserManager.AddToRoleAsync(user, "Client");

            }
            return Result;

        }
    }
}
