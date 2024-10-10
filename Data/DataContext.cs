using Microsoft.EntityFrameworkCore;
using Proyecto_Atenciones_Enfermeria.Models;

namespace Proyecto_Atenciones_Enfermeria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Define un DbSet por cada entidad (tabla)
        public DbSet<Efector> Efectores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Derivacion> Derivaciones { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
        public DbSet<TipoPrestacion> TiposPrestacion { get; set; }
        public DbSet<Prestacion> Prestaciones { get; set; }
        public DbSet<RegistroAtencion> RegistrosAtencion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar filtro global para cada entidad que tenga la propiedad Borrado
            modelBuilder.Entity<Efector>().HasQueryFilter(e => !e.Borrado);
            modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.Borrado);
            modelBuilder.Entity<Paciente>().HasQueryFilter(p => !p.Borrado);
            modelBuilder.Entity<Derivacion>().HasQueryFilter(d => !d.Borrado);
            modelBuilder.Entity<Atencion>().HasQueryFilter(a => !a.Borrado);
            modelBuilder.Entity<TipoPrestacion>().HasQueryFilter(t => !t.Borrado);
            modelBuilder.Entity<Prestacion>().HasQueryFilter(p => !p.Borrado);
            modelBuilder.Entity<RegistroAtencion>().HasQueryFilter(r => !r.Borrado);

            base.OnModelCreating(modelBuilder);
        }
    }
}
