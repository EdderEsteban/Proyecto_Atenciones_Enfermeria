namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Efector
    {
        public int Id_efector { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public string? Programa { get; set; }

        // Relación con la entidad Usuario
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
