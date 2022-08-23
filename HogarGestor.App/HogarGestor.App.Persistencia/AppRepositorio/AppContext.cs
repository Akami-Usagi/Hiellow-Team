namespace HogarGestor.App.Persistencia.AppRepositorio{
    using Microsoft.EntityFrameworkCore;
    using HogarGestor.App.Dominio;
    using HogarGestor.App.Persistencia;

    public class AppContext : DbContext{
        
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Medico> Medicos{get;set;}
        public DbSet<Familiar> Familiares{get;set;}
        public DbSet<Historia> Historias{get;set;}
        public DbSet<PatronesCrecimiento> PatronesCrecimientoJoven{get;set;}
        public DbSet<Joven> Jovenes{get;set;}
        public DbSet<SugerenciaCuidado> SugerenciasCuidado{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=HogarGestor");
            }
        }


    }
}