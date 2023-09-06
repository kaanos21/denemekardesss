using denemekardesss.DTOs;
using denemekardesss.Services.Abstract;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : ControllerBase
{
	private readonly StajProjectContext _context;
	private readonly IProductService _productService;

	public ProductController(StajProjectContext context, IProductService productService)
	{
		_context = context;
		_productService = productService;
	}


	[HttpGet("Food List")]
	public async Task<IActionResult> FoodList()
	{
		var response = await _productService.GetFoods();

		return Ok(response);
	}
	// HTTP GET metodu için bir örnek
	[HttpGet("Categori")]
	public IActionResult Get()
	{
		var c = new StajProjectContext();
		return Ok(c.Categories.ToList());
	}

	[HttpGet("id Category")]
	public IActionResult getbyıd(short id)
	{
		using var c = new StajProjectContext();
		var value = c.Categories.Find(id);
		if(value == null)
		{
			return NotFound();
		}
		else
		{
          return Ok(value);
		}
	}
	[HttpPost("Hesap Kurma")]
	public IActionResult GetMenu(CreateAccountDTO dto)
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
		return Created("", dto);
	}

	






	[HttpGet("Category Name Search")]
	public IActionResult CategorySearch(CategoryNameSearchDTO DTOO)
	{
		var c = new StajProjectContext();
		var catt = c.Categories.Where(x => x.Name.Contains(DTOO.CategoryName)).ToList();
		if (catt == null || !catt.Any())
		{
			return NotFound();
		}
		else
		{
			
			return Ok(catt);
		}
	}

	[HttpGet("Category Name Search Just return Name")]
	public IActionResult CategorySearchhh(string name)
	{
		var c = new StajProjectContext();
		var catt = c.Categories.Where(x => x.Name.Contains(name)).Select(x => x.Name).ToList();
		if (catt == null || !catt.Any())
		{
			return NotFound();
		}
		else
		{
			return Ok(catt);
		}
	}


	[HttpPost("Kategori Ekleme22")]
	public IActionResult KategoriEkleme(CategoryDTO dto)
	{
		var c = new StajProjectContext();
		var category = new Category
		{
			Name = dto.CategoryName
		};
		c.Add(category);
		c.SaveChanges();
		return Ok(dto);
	}
	[HttpPost("Menü Ekleme")]
	public IActionResult Menuekleme(MenuAddDTO dto)
	{
		var c = new StajProjectContext();
		var menuname = new MenuName
		{
			MenuName1 = dto.MenuName
		};
		c.Add(menuname);
		c.SaveChanges();
		return Ok(dto);
	}
	

	

	[HttpGet("Müşteri yemeği görsün")]
	public IActionResult MenuLıst()
	{
		var c = new StajProjectContext();
		
		var response = c.Foods.Select(x => new MenuLıstDTO
		{
			MenuName = x.Menu.MenuName1,
			Explanition = x.Explanition,
			Price = x.Price
		}).ToList();
		return Ok(response);
	}
           [HttpPost("YemekEkleme")]
	  public IActionResult YemekEkleme([FromBody] FoodAddDTO foodAddDTO)
	{
		var c = new StajProjectContext();

		
		var food = new Food
		{
			
			MenuId=foodAddDTO.MenuId,
			CategoryId = foodAddDTO.CategoryID,
			Price = foodAddDTO.Price,
			Explanition = foodAddDTO.Explanition
			
		};

		
		c.Foods.Add(food);
		c.SaveChanges();

		return Ok(foodAddDTO);
	}


	


	


	


	[HttpPost("Make a Orderslkfgmhmf GÜNCEL GÜNCEL GÜNCEL")]
	public IActionResult SiparisVerrrr3r(short userId, List<short> foodIds)
	{
		var c = new StajProjectContext();

		foreach (var foodId in foodIds)
		{
			// Yeni bir Order nesnesi oluştur
			var order = new Order
			{
				Time = DateTime.Now,
				OrderSituationId = 1,
				UserId = userId
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

		return Ok();
	}

	/*
	 * [HttpPut("Admin Sipariş Güncelleme")]
	public IActionResult siparisguncelle(Order oss)
	{
		var c = new StajProjectContext();
		var value = c.Find<OrderSituation>(oss.Id);
		if(value==null)
		{
			return NotFound();
		}
		else
		{
			value.Situation = oss.OrderSituationId;
			c.Update(value);
			c.SaveChanges();
			return NoContent();
		}
	}
	
	 */
	[HttpPost("Make a Orderslkfgmhmf GÜNCEL GÜNCEL GÜNCEL222222222222222")]
	public IActionResult SiparisVerr([FromBody] OrderDTO orderDTO)
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

		return Ok();
	}




	[HttpPut("Durum Güncelleme")]
	  public IActionResult UpdateOrderName(OrderUpdateDTO dto)
      {
		var context = new StajProjectContext();
    
        var order = context.Orders.FirstOrDefault(o => o.Id == dto.OrderID);
		
        if (order != null)
        {
            order.OrderSituationId = dto.OrderstationID;
            context.SaveChanges();
            return Ok(dto);
        }
        else
        {
            return NotFound();
        }
    
      }

	[HttpPut("Kullanıcı Para Yükleme")]

	public IActionResult UserMoneyyyy(UserMoneyTransactionsDTO Dto)
	{
		var context = new StajProjectContext();
		var sorgu = from x in context.Users where x.UserName == Dto.Username && x.UserPassword == Dto.UserPassword select x;

		if (sorgu.Any())
		{

			var a=context.Users.FirstOrDefault(x => x.UserName == Dto.Username);

			a.UserMoney = a.UserMoney+Dto.UserMoney;
		}
		context.SaveChanges();
		return Ok(Dto);
	}
	[HttpPut("Para Çekme")]
	public IActionResult UserMoneyyyy454(UserMoneyTransactionsDTO Dto)
	{
		var context = new StajProjectContext();
		var sorgu = from x in context.Users where x.UserName == Dto.Username && x.UserPassword == Dto.UserPassword select x;

		if (sorgu.Any())
		{

			var a = context.Users.FirstOrDefault(x => x.UserName == Dto.Username);

			a.UserMoney = a.UserMoney - Dto.UserMoney;
		}
		context.SaveChanges();
		return Ok(Dto);
	}

}


