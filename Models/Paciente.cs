namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Paciente
    {
        public int Id_paciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI { get; set; }
        public string? Telefono { get; set; }

        // Relación con la entidad Atencion
        public ICollection<Atencion>? Atenciones { get; set; }
    }
}
