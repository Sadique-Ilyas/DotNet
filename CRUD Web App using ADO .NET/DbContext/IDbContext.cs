namespace CRUD_Web_App_using_ADO_.NET.DbContext
{
	public interface IDbContext<T> where T : class
	{
		List<T> GetAll();
		T GetById(int id);
		bool Add(T obj);
		bool Update(T obj);
		bool Delete(T obj);
	}
}
