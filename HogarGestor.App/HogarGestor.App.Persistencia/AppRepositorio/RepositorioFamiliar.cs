using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {
        private readonly AppContext _appContext;

        public RepositorioFamiliar(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Familiar AddFamiliar(Familiar familiar)
        {
            var familiarAdicionado = _appContext.Familiares.Add(familiar);
            _appContext.SaveChanges();
            return familiarAdicionado.Entity;
        }

        public Familiar UpdateFamiliar(Familiar familiar)
        {
            var familiarEncontrado =
                _appContext.Familiares.FirstOrDefault(f => f.Id == familiar.Id);
            if (familiarEncontrado != null)
            {
                familiarEncontrado.Nombre = familiar.Nombre;
                familiarEncontrado.Apellido = familiar.Apellido;
                familiarEncontrado.Telefono = familiar.Telefono;
                familiarEncontrado.Documento = familiar.Documento;
                familiarEncontrado.TipoDocumentoId = familiar.TipoDocumentoId;
                familiarEncontrado.GeneroId = familiar.GeneroId;
                familiarEncontrado.Parentesco = familiar.Parentesco;
                familiarEncontrado.Correo = familiar.Correo;
                _appContext.SaveChanges();
            }
            return familiarEncontrado;
        }

        public void DeleteFamiliar(int idFamiliar)
        {
            var familiarEncontrado =
                _appContext.Familiares.FirstOrDefault(f => f.Id == idFamiliar);
            if (familiarEncontrado == null)
            {
                return;
            }
            _appContext.Familiares.Remove (familiarEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Familiar> GetAllFamiliar()
        {
            return _appContext.Familiares;
        }

        public Familiar GetFamiliar(int idFamiliar)
        {
            return _appContext
                .Familiares
                .FirstOrDefault(f => f.Id == idFamiliar);
        }

        public IEnumerable<Familiar> GetFilter(string filtro=null)
        {
            var familiares = this.GetAllFamiliar();
            if (familiares != null){
                if (!String.IsNullOrEmpty(filtro)){
                    familiares = familiares.Where(f => f.Documento.Contains(filtro));
                }
            }
            return familiares;
        }
    }
}