namespace EmployeeManagementAPI.Repositories.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Insert(T entity);
        Task Update(int id, T entity);
        Task DeleteById(int id);

    }
}
