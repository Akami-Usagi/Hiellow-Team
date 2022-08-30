using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Genero> Generos { get; set; }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Familiar> Familiares { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        //*************************************************************
        public DbSet<SugerenciaCuidado> Sugerencias { get; set; }

        public DbSet<Historia> Historias { get; set; }

        //************************************************************
        public DbSet<PatronesCrecimiento> PatronesCrecimiento { get; set; }
        //************************************************************
        public DbSet<Joven> Jovenes { get; set; }
        //public DbSet<MedicoPaciente> MedicoPaciente { get; set; }
        //*************************************************************
        //************************************************************
        //public DbSet<MedicoPaciente> MedicoPacientes { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HogarGestorData27;Trusted_Connection=True;");
            /// CAMBIAR EL DATA SOURCE AL NOMBRE DEL SERVIDOR INSTALADO EN CADA PC. EL MIO QUEDO CON ESE NOMBRE ENTONCES
            /// DEBEN CAMBIARLO AL NOMBRE DEL SERVIDOR DE CADA UNO, LOS DEMAS DATOS ESTAN BIEN Y FUNCIONALES.
        }
    }
}
