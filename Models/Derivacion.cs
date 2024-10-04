namespace Proyecto_Atenciones_Enfermeria.Models
{
    public class Derivacion
    {
        public int Id_derivacion { get; set; }
        public string? Tipo_traslado { get; set; }
        public string? Destino { get; set; }

        // Relación con Atencion
        public ICollection<Atencion>? Atenciones { get; set; }
    }
}
