using Ecommerce_SDA.Models.Product;
using Ecommerce_SDA.Models.User;
using Ecommerce_SDA.Models.User.Orders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SDA_Ecommerce.Models;
using SDA_Ecommerce.Models.Cart;

namespace Ecommerce_SDA.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Order> orders { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
