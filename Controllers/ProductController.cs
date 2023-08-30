using denemekardesss.DTOs;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : ControllerBase
{
	private readonly StajProjectContext _context;

	public ProductController(StajProjectContext context)
	{
		_context = context;
	}


	[HttpGet("Food List")]
	public IActionResult FoodList()
	{
		var c = new StajProjectContext();

		var response = c.Foods.Select(x => new FoodDTO
		{
			FoodID = x.Id,
			CategoryID = x.CategoryId,
			CategoryName = x.Category.Name ?? ""
		}).ToList();

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
	public IActionResult GetMenu(User u)
	{
		using var c = new StajProjectContext();
		c.Add(u);
		c.SaveChanges();
		return Created("", u);
	}

	

	[HttpGet("Category Name Search")]
	public IActionResult CategorySearch(string name)
	{
		var c = new StajProjectContext();
		var catt = c.Categories.Where(x => x.Name.Contains(name)).ToList();
		if (catt == null || !catt.Any())
		{
			return NotFound();
		}
		else
		{
			return Ok(catt);
		}
	}

	[HttpPost("Kategori Ekleme")]
	public IActionResult KategoriEkleme(string CategoryName)
	{
		var c = new StajProjectContext();
		var category = new Category { Name = CategoryName };
		c.Categories.Add(category);
		c.SaveChanges();
		return Ok(category);
	}
	[HttpPost("Menü Ekleme")]
	public IActionResult Menuekleme(string MenuName)
	{
		var c = new StajProjectContext();
		var menuu = new MenuName { MenuName1 = MenuName };
		c.MenuNames.Add(menuu);
		c.SaveChanges();
		return Ok(menuu);
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

		return Ok(food);
	}
	[HttpPost("Make a Order24234")]
	public IActionResult Sıparısver(short Userordıd,short fooood,short yemek)
	{
		int i;
		for (i = 0;  i < 4; i++)
		{
			var c = new StajProjectContext();
			var aa = c.Foods.Select(x => new OrderDTO
			{
				UserIdOrder = Userordıd,
				Foods = fooood
			}) ;
		}

		return Ok();

		/*var aa = c.Foods.Select(x => new
		{

		});
		
		var order = c.Orders.Select(x => new OrderDTO
		{
            UserIdOrder=Userordıd,
			Foods=fooood
		});*/


	}


	[HttpPost("Make a Order")]
	public IActionResult SiparisVer(short UserordId, Array fooood)
	{
		var c = new StajProjectContext();

		// Yeni bir Order nesnesi oluştur
		var order = new Order
		{
			Time = DateTime.Now,
			OrderSituationId = 1,
			UserId = UserordId
		};
		var value = c.OrderLists.FirstOrDefault();
		if (value != null)
		{
			var FoodId = value.FoodId;
		}


		// Order nesnesini veritabanına ekle
		c.Orders.Add(order);
		c.SaveChanges();

		return Ok(order);
	}


	[HttpPost("Make aa yapay zeka Order")]
	public IActionResult SiparisVer(short userId, List<short> foodIds)
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

			// Yeni bir OrderList nesnesi oluştur
			var orderList = new OrderList
			{
				OrderId = order.Id,
				FoodId = foodId
			};

			// Order ve OrderList nesnelerini veritabanına ekle
			c.Orders.Add(order);
			c.OrderLists.Add(orderList);
		}

		// Değişiklikleri kaydet
		c.SaveChanges();

		return Ok();
	}


	[HttpPost("Make a Orderslkfgmhmf")]
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





	[HttpPut("Durum Güncelleme")]
	  public IActionResult UpdateOrderName(int id, short newName)
{
		var context = new StajProjectContext();
    
        var order = context.Orders.FirstOrDefault(o => o.Id == id);
		
        if (order != null)
        {
            order.OrderSituationId = newName;
            context.SaveChanges();
            return Ok(order);
        }
        else
        {
            return NotFound();
        }
    
}
	 




}


