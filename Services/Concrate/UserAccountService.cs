using denemekardesss.DTOs;
using denemekardesss.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace denemekardesss.Services.Concrate
{
	public class UserAccountService : IUserAccountService
	{
		private readonly StajProjectContext _context;

		public UserAccountService(StajProjectContext context)
		{
			_context = context;
		}

		public async Task<CreateAccountDTO> createAcc(CreateAccountDTO dto)
		{
			using var c = new StajProjectContext();
			var user = new User
			{
				UserName = dto.UserName,
				UserPassword = dto.Password,
				UserMoney = dto.UserMoney
			};
			c.Add(user);
			c.SaveChanges();
			return dto;
		}

		public async Task<UserMoneyTransactionsDTO> UserAddMoney(UserMoneyTransactionsDTO Dto)
		{
			var context = new StajProjectContext();
			var sorgu = from x in context.Users where x.UserName == Dto.Username && x.UserPassword == Dto.UserPassword select x;

			if (sorgu.Any())
			{

				var a = context.Users.FirstOrDefault(x => x.UserName == Dto.Username);

				a.UserMoney = a.UserMoney + Dto.UserMoney;
			}
			context.SaveChanges();
			return Dto;
		}

		public async Task<UserMoneyTransactionsDTO> UserWithdrawMoney(UserMoneyTransactionsDTO Dto)
		{
			var context = new StajProjectContext();
			var sorgu = from x in context.Users where x.UserName == Dto.Username && x.UserPassword == Dto.UserPassword select x;

			if (sorgu.Any())
			{

				var a = context.Users.FirstOrDefault(x => x.UserName == Dto.Username);

				a.UserMoney = a.UserMoney - Dto.UserMoney;
			}
			context.SaveChanges();
			return Dto;
		}

		public async Task<OrderDTO> MakeOrder(OrderDTO orderDTO)
		{
			var c = new StajProjectContext();

			foreach (var foodId in orderDTO.FoodIds)
			{
				// Yeni bir Order nesnesi oluştur
				var order = new Order
				{
					Time = DateTime.Now,
					OrderSituationId = 1,
					UserId = orderDTO.UserId
				};

				// Order nesnesini veritabanına ekle
				c.Orders.Add(order);
				c.SaveChanges();  // Bu satırı ekleyin

				// Yeni bir OrderList nesnesi oluştur
				var orderList = new OrderList
				{
					OrderId = order.Id,  // Bu satırı değiştirin
					FoodId = foodId
				};

				// OrderList nesnesini veritabanına ekle
				c.OrderLists.Add(orderList);
			}

			// Değişiklikleri kaydet
			c.SaveChanges();
			return orderDTO;
		}

		[HttpGet("Kategori Arama")]

		public async Task<List<CategoryNameSearchDTO>> NameSearch(string name)
		{
			var c = new StajProjectContext();
			var catt = await c.Categories.Where(x => x.Name.Contains(name)).Select(x => new CategoryNameSearchDTO()
			{
				CategoryName = x.Name
			}).ToListAsync();

			return catt;
		}

		[HttpGet("Yemek Lİstesi")]

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

