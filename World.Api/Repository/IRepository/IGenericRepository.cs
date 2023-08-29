using System.Linq.Expressions;


namespace World.Api.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task Save();

        bool IsRecordExists(Expression<Func<T,bool>> condition);
    }
}
