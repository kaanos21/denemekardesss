using denemekardesss.DTOs;

namespace denemekardesss.Services.Abstract
{
	public interface IAdminService
	{
		Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);
		Task<MenuAddDTO> CreateMenu(MenuAddDTO menuAddDTO);
		Task<FoodAddDTO> FoodAdd(FoodAddDTO foodAddDTO);
		Task<OrderUpdateDTO> OrderUpdate(OrderUpdateDTO orderUpdateDTO);
	}
}
