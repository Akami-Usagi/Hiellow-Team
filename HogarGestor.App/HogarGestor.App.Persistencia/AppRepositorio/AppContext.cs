using Microsoft.EntityFrameworkCore;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia{
    
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
                optionsBuilder.UseSqlServer("data source=LocalHost;Initial Catalog=HogarGestor;Trusted_Connection=True;");
                /// CAMBIAR EL DATA SOURCE AL NOMBRE DEL SERVIDOR INSTALADO EN CADA PC. EL MIO QUEDO CON ESE NOMBRE ENTONCES 
                /// DEBEN CAMBIARLO AL NOMBRE DEL SERVIDOR DE CADA UNO, LOS DEMAS DATOS ESTAN BIEN Y FUNCIONALES.
            }
        }


    }
}