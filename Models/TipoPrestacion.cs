using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class TipoPrestacion
    {
        [Key]
        public int Id_tipo_prestacion { get; set; }
        public string? Tipo_prestacion { get; set; }
        public bool Borrado { get; set; } = false;

        // Relación con Prestacion
        public ICollection<Prestacion>? Prestaciones { get; set; }
    }
}
