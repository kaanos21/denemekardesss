using denemekardesss.DTOs;
using denemekardesss.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace denemekardesss.Services.Concrate
{
	public class AdminService :IAdminService
	{
		private readonly StajProjectContext _context;

		public AdminService(StajProjectContext context)
		{
			_context = context;
		}

		
		public async Task<CategoryDTO> CreateCategory(CategoryDTO dto)
		{
			var c = new StajProjectContext();
			var category = new Category
			{
				Name = dto.CategoryName
			};
			c.Add(category);
			c.SaveChanges();
			return dto;
		}

		public async Task<MenuAddDTO> CreateMenu(MenuAddDTO dto)
		{
			var c = new StajProjectContext();
			var menuname = new MenuName
			{
				MenuName1 = dto.MenuName
			};
			c.Add(menuname);
			c.SaveChanges();
			return dto;
		}

		public async Task<FoodAddDTO> FoodAdd(FoodAddDTO foodAddDTO)
		{
			var c = new StajProjectContext();


			var food = new Food
			{

				MenuId = foodAddDTO.MenuId,
				CategoryId = foodAddDTO.CategoryID,
				Price = foodAddDTO.Price,
				Explanition = foodAddDTO.Explanition

			};


			c.Foods.Add(food);
			c.SaveChanges();

			return foodAddDTO;
		}

		public async Task<OrderUpdateDTO> OrderUpdate(OrderUpdateDTO dto)
		{
			var context = new StajProjectContext();

			var order = context.Orders.FirstOrDefault(o => o.Id == dto.OrderID);

			if (order != null)
			{
				order.OrderSituationId = dto.OrderstationID;
				context.SaveChanges();
				return dto;
			}
			else
			{
				return null;
			}
		}
	}
}
