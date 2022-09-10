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
                    Nombre = "Francisco",
                    Apellidos = "Ortiz",
                    Documento = "123456",
                    NumeroTelefono = "315000000",
                    Genero = Generos.Masculino,
                    TarjetaProfesional = "123456",
                    Rethus = "123456",
                    EspecialidadMedica = Especialidad.Nutricion
                    
            
                },
                new Medico{
                    Id = 2,
                    Nombre = "Christian",
                    Apellidos = "Buitrago",
                    Documento = "654321",
                    NumeroTelefono = "3105555555",
                    Genero = Generos.Masculino,
                    TarjetaProfesional = "654321",
                    Rethus = "654321",
                    EspecialidadMedica = Especialidad.Pediatria 
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

        public IEnumerable<Medico> GetFiltro(string filtro)
        {
            var Medicos = this.GetAll();
            if (Medicos != null){
                if (!String.IsNullOrEmpty(filtro)){
                    Medicos = Medicos.Where(j => j.Nombre.Contains(filtro));
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