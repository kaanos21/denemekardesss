using denemekardesss.DTOs;
using denemekardesss.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using denemekardesss.Services.Concrate;

namespace denemekardesss.Controllers
{
	public class AdminController : Controller
	{
		private readonly StajProjectContext _context;

		private readonly IAdminService _AdminService;

		public AdminController(StajProjectContext context, IAdminService adminService)
		{
			_context = context;
			_AdminService = adminService;
		}

		[HttpPost("KategoriEkleme")]

		public async Task<IActionResult> AddCategory(CategoryDTO dto)
		{
			var response = await _AdminService.CreateCategory(dto);
			return Ok(response);
		}

		[HttpPost("MenuNameAdd")]

		public async Task<IActionResult> MenuNameAdd(MenuAddDTO dto)
		{
			var response = await _AdminService.CreateMenu(dto);
			return Ok(response);
		}

		[HttpPost("FoodAdd")]

		public async Task<IActionResult> FoodAdd(FoodAddDTO dto)
		{
			var response = await _AdminService.FoodAdd(dto);
			return Ok(response);
		}

		[HttpPut("OrderUpdate")]

		public async Task<IActionResult> OrderUpdate(OrderUpdateDTO dto)
		{
			var response = await _AdminService.OrderUpdate(dto);
			return Ok(response);
		}
	}
}
