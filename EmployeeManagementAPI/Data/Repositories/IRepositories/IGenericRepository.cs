namespace EmployeeManagementAPI.Data.Repositories.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task DeleteById(int id);

    }
}
