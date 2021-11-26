namespace SDA_Ecommerce.Models.ApiResponse
{
	public class CommonResponse<T>
	{
		public string massage { get; set; }
		public int status { get; set; }
		public T dataeum { get; set; }
	}
}
