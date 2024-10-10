using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class RegistroAtencion
    {
        [Key]
        public int Id_registro_atencion { get; set; }

        [ForeignKey("Atencion")]
        public int Id_atencion { get; set; }  // Llave foránea

        [ForeignKey("Prestacion")]
        public int Id_prestacion { get; set; } // Llave foránea
        public string? Observaciones { get; set; }

        // Propiedad de borrado
        public bool Borrado { get; set; } = false;

        // Relación con Atencion
        public Atencion? Atencion { get; set; }

        // Relación con Prestacion
        public Prestacion? Prestacion { get; set; }
    }
}
