using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Paciente
    {
        [Key]
        public int Id_paciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI { get; set; }
        public string? Telefono { get; set; }
        public bool Borrado { get; set; } = false;

        // Relación con la entidad Atencion
        public ICollection<Atencion>? Atenciones { get; set; }
    }
}
