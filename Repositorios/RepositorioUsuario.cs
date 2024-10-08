using Proyecto_Atenciones_Enfermeria.Data;
using Proyecto_Atenciones_Enfermeria.Models;

namespace Proyecto_Atenciones_Enfermeria.Repositorios
{
    public class UsuarioRepository : GenericRepository<Usuario>
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Puedes agregar métodos específicos de Usuario aquí si es necesario.
    }
}
