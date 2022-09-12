using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace HogarGestor.App.Persistencia{
    public class RepositorioJovenMemoria : IRepositorioJovenMemoria
    {

        List<Joven> Jovenes;
        public RepositorioJovenMemoria(){
            Jovenes = new List<Joven>(){
                new Joven{
                    Id = 1,
                    Nombre = "Camilo",
                    Apellidos = "Arango",
                    Documento = "1115066671",
                    DocumentoTipo = TipoDocumento.CedulaDeCiudadania,
                    NumeroTelefono = "3103565058",
                    Direccion = "Calle 7 # 12-34",
                    Ciudad = "Buga",
                    Genero = Generos.Masculino,
                    FechaNacimiento = new DateTime(1987,06,07)
                    
                },
                new Joven{
                    Id = 2,
                    Nombre = "Paola",
                    Apellidos = "Blandon",
                    Documento = "38878362",
                    DocumentoTipo = TipoDocumento.CedulaDeCiudadania,
                    NumeroTelefono = "3156661050",
                    Direccion = "Calle 8 # 11-19",
                    Ciudad = "Buga",
                    Genero = Generos.Femenino,
                    FechaNacimiento = new DateTime(1975,12,12)
                    
                },new Joven{
                    Id = 3,
                    Nombre = "Akemi",
                    Apellidos = "Arango",
                    Documento = "1112406770",
                    DocumentoTipo = TipoDocumento.TarjetaDeIdentidad,
                    NumeroTelefono = "3105325321",
                    Direccion = "Calle 7 # 12-34",
                    Ciudad = "Buga",
                    Genero = Generos.Femenino,
                    FechaNacimiento = new DateTime(2014,02,08)
                    
                }
            };

        }

        public Joven Add(Joven joven)
        {
            joven.Id = Jovenes.Max(j => j.Id)+1;
            Jovenes.Add(joven);
            return joven;
        }

        public void Delete(int IdJoven)
        {
            var joven = Jovenes.SingleOrDefault(j => j.Id == IdJoven);
            if (joven == null){
                return;
            }
            Jovenes.Remove(joven);
        }

        public Joven Get(int IdJoven)
        {
            return Jovenes.SingleOrDefault(j => j.Id == IdJoven);
        }

        public IEnumerable<Joven> GetAll()
        {
            return Jovenes;
        }

        public Joven Update(Joven joven)
        {
            var JovenEncontrado = Jovenes.SingleOrDefault(j => j.Id == joven.Id);
            if (JovenEncontrado != null){
                JovenEncontrado.Nombre = joven.Nombre;
                JovenEncontrado.Apellidos = joven.Apellidos;
                JovenEncontrado.NumeroTelefono = joven.NumeroTelefono;
                JovenEncontrado.Genero = joven.Genero;
                JovenEncontrado.DocumentoTipo = joven.DocumentoTipo;
                JovenEncontrado.Direccion = joven.Direccion;
                JovenEncontrado.Latitud = joven.Latitud;
                JovenEncontrado.Longitud = joven.Longitud;
                JovenEncontrado.Ciudad = joven.Ciudad;
                JovenEncontrado.FechaNacimiento = joven.FechaNacimiento;
                JovenEncontrado.FamiliarDesignado = joven.FamiliarDesignado;
                JovenEncontrado.Nutricionista = JovenEncontrado.Nutricionista;
                JovenEncontrado.Pediatra = JovenEncontrado.Pediatra;
                JovenEncontrado.HistoriaJoven = joven.HistoriaJoven;

            }
            return JovenEncontrado;
        }

        public IEnumerable<Joven> GetFiltro(string filtro=null)
        {
            var jovenes = this.GetAll();
            if (jovenes != null){
                if (!String.IsNullOrEmpty(filtro)){
                    jovenes = jovenes.Where(j => j.Nombre.Contains(filtro));
                }
            }
            return jovenes;
        }

        public Medico ToAssignMedicoPediatra(int IdJoven, Medico Pediatra)
        {
            var JovenEncontrado = Jovenes.SingleOrDefault(j => j.Id == IdJoven);
            if(JovenEncontrado!=null){
                JovenEncontrado.Pediatra = Pediatra;
                return Pediatra;
            }
            return null;
        }

        public Medico ToAssignMedicoNutricionista(int IdJoven, Medico Nutricionista)
        {
            var JovenEncontrado = Jovenes.SingleOrDefault(j => j.Id == IdJoven);
            if(JovenEncontrado!=null){
                JovenEncontrado.Nutricionista = Nutricionista;
                return Nutricionista;
            }
            return null;
        }
    }
}