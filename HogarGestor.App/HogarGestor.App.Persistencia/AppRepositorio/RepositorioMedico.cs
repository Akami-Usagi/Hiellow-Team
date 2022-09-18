using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;
        public RepositorioMedico(AppContext appContext){
            _appContext = appContext;
        }


        public Medico AddMedico(Medico medico)
        {
            var MedicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return MedicoAdicionado.Entity;
        }

        public void DeleteMedico(int IdMedico)
        {
            var MedicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == IdMedico);
            if (MedicoEncontrado == null){
                return;
            }
            _appContext.Medicos.Remove(MedicoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Medico> GetAllMedicos()
        {
            return _appContext.Medicos;
        }

        public Medico GetMedico(int IdMedico)
        {
            var MedicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == IdMedico);
            return MedicoEncontrado;
        }

        public Medico UpdateMedico(Medico medico)
        {
            var MedicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == medico.Id);
            if (MedicoEncontrado != null){
                MedicoEncontrado.Nombre = medico.Nombre;
                MedicoEncontrado.Apellidos = medico.Apellidos;
                MedicoEncontrado.NumeroTelefono = medico.NumeroTelefono;
                MedicoEncontrado.Genero = medico.Genero;
                MedicoEncontrado.DocumentoTipo = medico.DocumentoTipo;
                MedicoEncontrado.EspecialidadMedica = medico.EspecialidadMedica;
                MedicoEncontrado.Rethus = medico.Rethus;
                MedicoEncontrado.TarjetaProfesional = medico.TarjetaProfesional;

                _appContext.SaveChanges();

            }
            return MedicoEncontrado;

        }

        public IEnumerable<Medico> GetAllNutricionistas(Especialidad especialidad)
        {
            var nutricionistas = _appContext.Medicos.Where(m => m.EspecialidadMedica == especialidad);
            return nutricionistas;
        }

        public IEnumerable<Medico> GetAllPediatras(Especialidad especialidad)
        {
            var pediatras = _appContext.Medicos.Where(m => m.EspecialidadMedica == especialidad);
            return pediatras;
        }

        public IEnumerable<Joven> JovenesAsignadosPediatra(int IdMedico)
        {
            return _appContext.Jovenes.Where(j => j.Pediatra.Id == IdMedico).ToList();
        }

        public IEnumerable<Joven> JovenesAsignadosNutricionista(int IdMedico)
        {
            return _appContext.Jovenes.Where(j => j.Nutricionista.Id == IdMedico).ToList();
        }

        public IEnumerable<PatronesCrecimiento> GetPatronesPaciente(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j => j.HistoriaJoven).FirstOrDefault();
            return joven.HistoriaJoven.PatronCrecimiento;
        }
    }
}