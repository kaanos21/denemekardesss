namespace denemekardesss.Services.Abstract
{
	public interface IRepository<T>
	{
		int insert(T p);
		int update(T p);
		int Delete(T p);
		List<T> List();
		T GetById(int id);
	}
}
