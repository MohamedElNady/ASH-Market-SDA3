using Microsoft.AspNetCore.Identity;
using SDA_Ecommerce.Models;
using SDA_Ecommerce.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDA_Ecommerce.Service
{
	public interface IServices
	{
		Task<string> AddProduct(ProductDetails product); 
		Task<IdentityResult> SignUp(SignUpVM model);
		Task<string> Login(LoginVM model);
		Task<string> Logout();
		IEnumerable<ProductDetails> GetAllLaptopProducts();

		ProductDetails GetProductDetails(int id);
		Task<string> DeletedItem(int id);
		Task<string> EditItemData(ProductDetails model);
	}
}
