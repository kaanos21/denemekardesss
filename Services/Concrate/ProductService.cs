using denemekardesss.DTOs;
using denemekardesss.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace denemekardesss.Services.Concrate
{
	public class ProductService : IProductService
	{
		private readonly StajProjectContext _context;

		public ProductService(StajProjectContext context)
		{
			_context = context;
		}

		public async Task<List<FoodDTO>> GetFoods()
		{
			var c = new StajProjectContext();

			var response = await c.Foods.Select(x => new FoodDTO
			{
				FoodID = x.Id,
				CategoryID = x.CategoryId,
				CategoryName = x.Category.Name ?? ""
			}).ToListAsync();

			return response;
		}

		

		



	}
}
