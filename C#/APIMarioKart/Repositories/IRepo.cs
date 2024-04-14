using APIMarioKart.Models;

namespace APIMarioKart.Repositories
{
    public interface IRepo<T>
    {
        T? Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}
