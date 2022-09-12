using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioFamiliarMemoria : IRepositorioFamiliarMemoria
    {
        List<Familiar> Familiares;

        public RepositorioFamiliarMemoria(){
             Familiares = new List<Familiar>(){
                new Familiar{
                    Id = 1,
                    Nombre = "Dalia",
                    Apellido = "Rojas",
                    Telefono="323439129",
                    Documento = "342156789",
                    GeneroId = 2,
                    Parentesco = "Madre",
                    Correo = "daliarojas@gmail.com"
                }
               
            };
        }
        public IEnumerable<Familiar> GetAll(){
            return Familiares;
        }

        public Familiar Add(Familiar familiar){
            familiar.Id = Familiares.Max(f => f.Id)+1;
            Familiares.Add(familiar);
            return familiar;
        }

        public Familiar Update(Familiar familiar){
             throw new NotImplementedException();
        }

        public void Delete(int familiarId){
            Familiar familiar = Familiares.SingleOrDefault(f => f.Id == familiarId);
            Familiares.Remove(familiar);
        }

        public Familiar Get(int familiarId){
            return Familiares.SingleOrDefault(f => f.Id == familiarId);
        }

        public IEnumerable<Familiar> GetFilter(string filtro){
           var Familiares = this.GetAll();
            if (Familiares != null){
                if (!String.IsNullOrEmpty(filtro)){
                    Familiares = Familiares.Where(f => f.Documento.Contains(filtro));
                }
            }
            return Familiares;
        }
    }
}