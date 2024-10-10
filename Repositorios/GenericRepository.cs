// Repositorio que implementa todos los métodos definidos en IGenericRepository.

using Microsoft.EntityFrameworkCore;
using Proyecto_Atenciones_Enfermeria.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Atenciones_Enfermeria.Repositorios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context; // Contexto de la base de datos
        private readonly DbSet<T> _dbSet;               // Referencia a la tabla específica

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();                 // Obtener la tabla específica
        }

        // Metodo para obtener todos los registros
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Obtener todos los registros con borrado = 0
            return await _dbSet.Where(e => !EF.Property<bool>(e, "Borrado")).ToListAsync();
        }

        // Metodo para obtener un registro por su ID
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            // Revisar el borrado....
            if (entity != null)
            {
                return null;
            }
            return entity;
        }

        // Metodo para agregar un nuevo registro
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);               // Agregar nuevo registro
            await _context.SaveChangesAsync();           // Guardar cambios en la base de datos
        }

        // Metodo para actualizar un registro
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);                       // Actualizar registro existente
            await _context.SaveChangesAsync();           // Guardar cambios
        }

        // Metodo para borrar un registro
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);                       // Borrar registro
            await _context.SaveChangesAsync();           // Guardar cambios
        }

    }
}
