using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioJoven : IRepositorioJoven
    {
        private readonly AppContext _appContext;

        public RepositorioJoven(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Joven AddJoven(Joven joven)
        {
            var jovenAdicionado = _appContext.Jovenes.Add(joven);
            _appContext.SaveChanges();
            return jovenAdicionado.Entity;
        }

        public Joven UpdateJoven(Joven joven)
        {
            var jovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(j => j.Id == joven.Id);
            if (jovenEncontrado != null)
            {
                jovenEncontrado.Nombre = joven.Nombre;
                jovenEncontrado.Apellido = joven.Apellido;
                jovenEncontrado.Telefono = joven.Telefono;
                jovenEncontrado.Documento = joven.Documento;
                jovenEncontrado.TipoDocumentoId = joven.TipoDocumentoId;
                jovenEncontrado.GeneroId = joven.GeneroId;
                jovenEncontrado.Direccion = joven.Direccion;
                jovenEncontrado.Latitud = joven.Latitud;
                jovenEncontrado.Longitud = joven.Longitud;
                jovenEncontrado.Ciudad = joven.Ciudad;
                jovenEncontrado.FechaNacimiento = joven.FechaNacimiento;
                jovenEncontrado.FamiliarId = joven.FamiliarId;
                jovenEncontrado.NutricionistaId = joven.NutricionistaId;
                jovenEncontrado.PediatraId = joven.PediatraId;
                _appContext.SaveChanges();
            }
            return jovenEncontrado;
        }

        public void DeleteJoven(int idJoven)
        {
            var jovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(p => p.Id == idJoven);
            if (jovenEncontrado == null)
            {
                return;
            }
            _appContext.Jovenes.Remove (jovenEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Joven> GetAllJovenes()
        {
            return _appContext.Jovenes;
        }

        public Joven GetJoven(int idJoven)
        {
            return _appContext.Jovenes.FirstOrDefault(j => j.Id == idJoven);
        }
    }
}
