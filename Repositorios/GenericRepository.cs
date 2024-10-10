using Microsoft.EntityFrameworkCore;
using Proyecto_Atenciones_Enfermeria.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Atenciones_Enfermeria.Repositorios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context; // Contexto de la base de datos
        private readonly DbSet<T> _dbSet;      // Referencia a la tabla específica

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();  // Obtener la tabla específica
        }

        // Metodo para obtener todos los registros (filtro de borrado aplicado globalmente)
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();  // El filtro global excluye los registros con Borrado = true
        }

        // Metodo para obtener un registro por su ID
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                return null;

            // Imprimir detalles del objeto en consola para depuración
            Console.WriteLine("Estoy en Generic mirando:");
            foreach (var prop in entity.GetType().GetProperties())
            {
                var value = prop.GetValue(entity, null);
                Console.WriteLine($"{prop.Name}: {value}");
            }

            return entity;  // Devuelve la entidad si existe
        }

        // Metodo para agregar un nuevo registro
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);  // Agregar nuevo registro
            await _context.SaveChangesAsync();  // Guardar cambios en la base de datos
        }

        // Metodo para actualizar un registro existente
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);  // Actualizar el registro
            await _context.SaveChangesAsync();  // Guardar cambios en la base de datos
        }

        // Metodo para realizar un borrado físico (eliminar el registro permanentemente)
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);  // Borrar el registro
                await _context.SaveChangesAsync();  // Guardar cambios
            }
        }

        // Metodo para realizar un borrado lógico (cambiar Borrado a true)
        public async Task LogicalDeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                // Usar reflection para establecer la propiedad "Borrado" a true
                var borradoProp = entity.GetType().GetProperty("Borrado");
                if (borradoProp != null && borradoProp.CanWrite)
                {
                    borradoProp.SetValue(entity, true);  // Cambiar Borrado a true
                    await _context.SaveChangesAsync();  // Guardar cambios
                }
            }
        }
    }
}
