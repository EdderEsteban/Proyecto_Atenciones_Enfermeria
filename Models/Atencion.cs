using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Atenciones_Enfermeria.Models

{
    public class Atencion
    {
        [Key]
        public int Id_atencion { get; set; }
        [ForeignKey("Usuario")]
        public int Id_usuario { get; set; }  
        [ForeignKey("Paciente")]
        public int Id_paciente { get; set; } 
        [ForeignKey("Derivacion")]
        public int? Id_derivacion { get; set; } 
        public string? Tipo_atencion { get; set; }
        public DateTime Fecha_atencion { get; set; } 
        public TimeSpan Hora_atencion { get; set; }

        // Relación con Usuario
        public Usuario? Usuario { get; set; }
 
        // Relación con Paciente
        public Paciente? Paciente { get; set; }

        // Relación con Derivacion
        public Derivacion? Derivacion { get; set; }

        // Propiedad de borrado
        public bool Borrado { get; set; } = false;


        // Relación con RegistroAtencion
        public ICollection<RegistroAtencion>? RegistrosAtencion { get; set; }
    }
}
