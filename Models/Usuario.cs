namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public int Id_efector { get; set; } 
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Hash_Password { get; set; }
        public string? Rol { get; set; }

        // Relación con la entidad Efector
        public Efector? Efector { get; set; }

        // Relación con la entidad Atencion
        public ICollection<Atencion>? Atenciones { get; set; }
    }
}
