namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class RegistroAtencion
    {
        public int Id_registro_atencion { get; set; }
        public int Id_atencion { get; set; }  // Llave foránea
        public int Id_prestacion { get; set; } // Llave foránea
        public string? Observaciones { get; set; }

        // Relación con Atencion
        public Atencion? Atencion { get; set; }

        // Relación con Prestacion
        public Prestacion? Prestacion { get; set; }
    }
}
