// Repositorio que implementa todos los métodos definidos en IGenericRepository.

using Microsoft.EntityFrameworkCore;
using Proyecto_Atenciones_Enfermeria.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Atenciones_Enfermeria.Repositorios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context; // Contexto de la base de datos
        private readonly DbSet<T> _dbSet;               // Referencia a la tabla específica

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();                 // Obtener la tabla específica
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();           // Obtener todos los registros
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);           // Obtener un registro por ID
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);               // Agregar nuevo registro
            await _context.SaveChangesAsync();           // Guardar cambios en la base de datos
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);                       // Actualizar registro existente
            await _context.SaveChangesAsync();           // Guardar cambios
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);     // Buscar el registro
            if (entity != null)
            {
                _dbSet.Remove(entity);                   // Eliminar el registro
                await _context.SaveChangesAsync();       // Guardar cambios
            }
        }
    }
}
