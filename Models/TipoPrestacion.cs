using System.ComponentModel.DataAnnotations;

namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class TipoPrestacion
    {
        [Key]
        public int Id_tipo_prestacion { get; set; }
        public string? Tipo_prestacion { get; set; }

        // Propiedad de borrado
        public bool Borrado { get; set; } = false;

        // Relación con Prestacion
        public ICollection<Prestacion>? Prestaciones { get; set; }
    }
}
