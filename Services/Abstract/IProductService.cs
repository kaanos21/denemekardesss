using denemekardesss.DTOs;

namespace denemekardesss.Services.Abstract
{
	public interface IProductService
	{
		Task<List<FoodDTO>> GetFoods();

		
	}
}
