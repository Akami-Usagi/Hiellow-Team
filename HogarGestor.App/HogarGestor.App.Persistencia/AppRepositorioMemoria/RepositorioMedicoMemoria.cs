using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
namespace HogarGestor.App.Persistencia
{
    public class RepositorioMedicoMemoria : IRepositorioMedicoMemoria
    {
      List<Medico> Medicos;
        public RepositorioMedicoMemoria(){
            Medicos = new List<Medico>(){
                new Medico{
                    Id = 1,
                    Nombre = "Solangiue",
                    Apellido = "Alvarez",
                    Documento = "123456",
                    Telefono = "315000000",
                    GeneroId = 2,
                    TarjetaProfesional = "123456",
                    Rethus = "123456",
                    Especialidad = Especialidad.Nutricion
                    
            
                },
                new Medico{
                    Id = 2,
                    Nombre = "Diana Juliet",
                    Apellido = "Velasco",
                    Documento = "654321",
                    Telefono = "3105555555",
                    GeneroId = 2,
                    TarjetaProfesional = "654321",
                    Rethus = "654321",
                    Especialidad = Especialidad.Pediatria 
                }
            };
        }


        public Medico Add(Medico medico)
        {
            medico.Id = Medicos.Max(m => m.Id)+1;
            Medicos.Add(medico);
            return medico;
        }

        public void Delete(int IdMedico)
        {
            Medico medico = Medicos.SingleOrDefault(m => m.Id == IdMedico);
            Medicos.Remove(medico);
        }

        public Medico Get(int IdMedico)
        {
            return Medicos.SingleOrDefault(m => m.Id == IdMedico);
        }

        public IEnumerable<Medico> GetAll()
        {
            return Medicos;
        }

        public IEnumerable<Medico> GetFilter(string filtro)
        {
            var Medicos = this.GetAll();
            if (Medicos != null){
                if (!String.IsNullOrEmpty(filtro)){
                    Medicos = Medicos.Where(j => j.Documento.Contains(filtro));
                }
            }
            return Medicos;
        }

        public Medico Update(Medico medico)
        {
            throw new NotImplementedException();
        }
    }
}