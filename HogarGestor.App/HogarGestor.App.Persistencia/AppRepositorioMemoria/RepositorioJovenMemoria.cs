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
            throw new NotImplementedException();
        }

        public void Delete(string DocumentoJoven)
        {
            throw new NotImplementedException();
        }

        public Joven Get(string DocumentoJoven)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Joven> GetAll()
        {
            return Jovenes;
        }

        public Joven Update(Joven joven)
        {
            throw new NotImplementedException();
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
    }
}