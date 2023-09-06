using denemekardesss.DTOs;
using denemekardesss.Services.Abstract;
using denemekardesss.Services.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace denemekardesss.Controllers
{
	public class UserAccountController : Controller
	{
		private readonly StajProjectContext _context;
		
		private readonly IUserAccountService _accountService;

		public UserAccountController(StajProjectContext context, IUserAccountService accountService)
		{
			_context = context;
			_accountService = accountService;
		}

		[HttpPost("Hesap Kurma Service ile")]
		public async Task<IActionResult> CreateAccount(CreateAccountDTO createAccountDTO)
		{
			var response = await _accountService.createAcc(createAccountDTO);
			return Ok(response);
		}
		[HttpPut("Hesaba Para Yükleme ")]

		public async Task<IActionResult> UserAddMoney(UserMoneyTransactionsDTO Dto)
		{
			var response = await _accountService.UserAddMoney(Dto);
			return Ok(response);
		}

		[HttpPut("Hesaptan Para Çekme ")]

		public async Task<IActionResult> UserWithdrawMoney(UserMoneyTransactionsDTO Dto)
		{
			var response = await _accountService.UserWithdrawMoney(Dto);
			return Ok(response);
		}

		[HttpPost("Sipariş Verme")]

		public async Task<IActionResult> MakeOrder(OrderDTO orderDTO)
		{
			var response = await _accountService.MakeOrder(orderDTO);
			return Ok(response);
		}

		[HttpGet("Kategori Arama")]

		public async Task<IActionResult> CategorySearch(string name)
		{
			var response = await _accountService.NameSearch(name);
			return Ok(response);
		}

		[HttpGet("Yemek Listesi")]

		public async Task<IActionResult> CategorySearch()
		{
			var response = await _accountService.GetFoods();
			return Ok(response);
		}



	}
}

