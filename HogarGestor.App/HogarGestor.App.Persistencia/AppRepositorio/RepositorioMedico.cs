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

        public IEnumerable<Medico>
        GetAllNutricionistas(Especialidad especialidad)
        {
            var nutricionistas =
                _appContext
                    .Medicos
                    .Where(m => m.Especialidad == especialidad);
            return nutricionistas;
        }

        public IEnumerable<Medico> GetAllPediatras(Especialidad especialidad)
        {
            var pediatras =
                _appContext
                    .Medicos
                    .Where(m => m.Especialidad == especialidad);
            return pediatras;
        }

         public IEnumerable<Medico> GetFilter(string filtro=null)
        {
            var familiares = this.GetAllMedico();
            if (familiares != null){
                if (!String.IsNullOrEmpty(filtro)){
                    familiares = familiares.Where(f => f.Documento.Contains(filtro));
                }
            }
            return familiares;
        }

        public IEnumerable<Joven> JovenesAsignadosPediatra(int IdMedico)
        {
            return _appContext.Jovenes.Where(j => j.PediatraId == IdMedico).ToList();
        }

        public IEnumerable<Joven> JovenesAsignadosNutricionista(int IdMedico)
        {
            return _appContext.Jovenes.Where(j => j.NutricionistaId == IdMedico).ToList();
        }
    }
}
