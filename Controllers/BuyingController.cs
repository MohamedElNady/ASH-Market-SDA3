using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SDA_Ecommerce.Models;
using SDA_Ecommerce.Models.ApiResponse;
using SDA_Ecommerce.Models.User.Orders;
using System.Collections.Generic;
using System.Net;

namespace SDA_Ecommerce.Controllers
{
	[Route("Buying")]
	public class BuyingController : Controller
	{
		[HttpPost("getData")]
		public IActionResult getData([FromBody]IEnumerable<Cookies> requestData)
		{
			CommonResponse<string> response = new();
			TempData.Remove("mydata");
			
		    TempData["mydata"] = JsonConvert.SerializeObject(requestData);
			
		
			response.status = 1;
			return Ok(response);
		}







		[HttpGet("Cart")]
		public IActionResult Cart()
		{
			ViewData["mydata"] = JsonConvert.DeserializeObject<List<Cookies>>((string)TempData["mydata"]);
			var data = ViewData["mydata"];
			return View(data);
		}
		[HttpGet("CheckOut")]
		[Authorize]
		public IActionResult CheckOut()
		{
			return View();
		}


	}
}
