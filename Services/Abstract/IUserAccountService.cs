using denemekardesss.DTOs;

namespace denemekardesss.Services.Abstract
{
	public interface IUserAccountService
	{
		Task<CreateAccountDTO> createAcc(CreateAccountDTO createAccountDTO);
		Task<UserMoneyTransactionsDTO> UserAddMoney(UserMoneyTransactionsDTO userMoneyTransactionsDTO);
		Task<UserMoneyTransactionsDTO> UserWithdrawMoney(UserMoneyTransactionsDTO userMoneyTransactionsDTO);
		Task<OrderDTO> MakeOrder(OrderDTO orderDTO);
		Task<List<CategoryNameSearchDTO>> NameSearch(string name);
		Task<List<FoodDTO>> GetFoods();


	}
}
