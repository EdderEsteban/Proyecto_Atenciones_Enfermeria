using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Atenciones_Enfermeria.Repositorios
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task LogicalDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
