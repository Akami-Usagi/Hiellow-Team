using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioFamiliarMemoria : IRepositorioFamiliarMemoria
    {

        List<Familiar> Familiares;
        public RepositorioFamiliarMemoria(){
            Familiares = new List<Familiar>(){
                new Familiar{
                    Id = 1,
                    Nombre = "Maria Virginia",
                    Apellidos = "Escobar",
                    Documento = "38859490",
                    Genero = Generos.Femenino,
                    Parentesco = "Madre",
                    CorreoElectronico = "vicky@gmail.com"
                    
            
                }
               
            };

        }
        
        public Familiar Add(Familiar familiar)
        {
            familiar.Id = Familiares.Max(m => m.Id)+1;
            Familiares.Add(familiar);
            return familiar;
        }

        public void Delete(int IdFamiliar)
        {
            Familiar familiar = Familiares.SingleOrDefault(f => f.Id == IdFamiliar);
            Familiares.Remove(familiar);
        }

        public Familiar Get(int IdFamiliar)
        {
            return Familiares.SingleOrDefault(m => m.Id == IdFamiliar);
        }

        public IEnumerable<Familiar> GetAll()
        {
            return Familiares;
        }

        public IEnumerable<Familiar> GetFiltro(string filtro)
        {
            var Familiares = this.GetAll();
            if (Familiares != null){
                if (!String.IsNullOrEmpty(filtro)){
                    Familiares = Familiares.Where(f => f.Nombre.Contains(filtro));
                }
            }
            return Familiares;
        }

        public Familiar Update(Familiar familiar)
        {
            throw new NotImplementedException();
        }
    }
}