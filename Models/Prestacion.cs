using System.ComponentModel.DataAnnotations;

namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Prestacion
    {
        [Key]
        public int Id_prestacion { get; set; }
        public int Id_tipo_prestacion { get; set; } // Llave foránea
        public string? PrestacionNombre { get; set; }

        // Relación con TipoPrestacion
        public TipoPrestacion? TipoPrestacion { get; set; }

        // Propiedad de borrado
        public bool Borrado { get; set; } = false;

        // Relación con RegistroAtencion
        public ICollection<RegistroAtencion>? RegistrosAtencion { get; set; }
    }
}
