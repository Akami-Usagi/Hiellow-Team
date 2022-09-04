
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;

        public RepositorioMedico(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Medico AddMedico(Medico medico)
        {
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity;
        }

        public Medico UpdateMedico(Medico medico)
        {
            var medicoEncontrado =
                _appContext.Medicos.FirstOrDefault(j => j.Id == medico.Id);
            if (medicoEncontrado != null)
            {
                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellido = medico.Apellido;
                medicoEncontrado.Telefono = medico.Telefono;
                medicoEncontrado.Documento = medico.Documento;
                medicoEncontrado.TipoDocumentoId = medico.TipoDocumentoId;
                medicoEncontrado.GeneroId = medico.GeneroId;
                medicoEncontrado.Rethus = medico.Rethus;
                medicoEncontrado.TarjetaProfesional = medico.TarjetaProfesional;
                medicoEncontrado.Especialidad = medico.Especialidad;
                _appContext.SaveChanges();
            }
            return medicoEncontrado;
        }

        public void DeleteMedico(int idMedico)
        {
            var medicoEncontrado =
                _appContext.Medicos.FirstOrDefault(p => p.Id == idMedico);
            if (medicoEncontrado == null)
            {
                return;
            }
            _appContext.Medicos.Remove (medicoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Medico> GetAllMedico()
        {
            return _appContext.Medicos;
        }

        public Medico GetMedico(int idMedico)
        {
            return _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
        }
    }
}
