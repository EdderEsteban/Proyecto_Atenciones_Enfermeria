using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Prestacion
    {
        [Key]
        public int Id_prestacion { get; set; }
        
        [ForeignKey("TipoPrestacion")]
        public int Id_tipo_prestacion { get; set; } // Llave foránea
        public string? PrestacionNombre { get; set; }
        public bool Borrado { get; set; } = false;

        // Relación con TipoPrestacion
        public TipoPrestacion? TipoPrestacion { get; set; }

        // Relación con RegistroAtencion
        public ICollection<RegistroAtencion>? RegistrosAtencion { get; set; }
    }
}
