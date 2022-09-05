using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

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

        public void DeleteMedico(string DocumentoMedico)
        {
            var MedicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Documento == DocumentoMedico);
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

        public Medico GetMedico(string DocumentoMedico)
        {
            var MedicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Documento == DocumentoMedico);
            return MedicoEncontrado;
        }

        public Medico UpdateMedico(Medico medico)
        {
            var MedicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Documento == medico.Documento);
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
    }
}