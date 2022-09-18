using System.Linq;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

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

        public Medico ToAssignNutricionista(int IdJoven, Medico nutricionista)
        {
            var JovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if (JovenEncontrado != null)
            {
                JovenEncontrado.Nutricionista = nutricionista;
                _appContext.SaveChanges();
                return nutricionista;
            }
            return null;
        }

        public Medico ToAssignPediatra(int IdJoven, Medico pediatra)
        {
            var JovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if (JovenEncontrado != null)
            {
                JovenEncontrado.Pediatra = pediatra;
                _appContext.SaveChanges();
                return pediatra;
            }
            return null;
        }

        public IEnumerable<Joven> GetFilter(string filtro = null)
        {
            var jovenes = this.GetAllJovenes();
            if (jovenes != null)
            {
                if (!String.IsNullOrEmpty(filtro))
                {
                    jovenes = jovenes.Where(j => j.Documento.Contains(filtro));
                }
            }
            return jovenes;
        }

        public Familiar ToAssignFamiliar(int IdJoven, Familiar familiar)
        {
            var JovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if (JovenEncontrado != null)
            {
                JovenEncontrado.Familiar = familiar;
                _appContext.SaveChanges();
                return familiar;
            }
            return null;
        }

        public Medico ConsultarMedicoNutricionista(int idJoven)
        {
            var joven =
                _appContext
                    .Jovenes
                    .Where(p => p.Id == idJoven)
                    .Include(p => p.Nutricionista)
                    .FirstOrDefault();
            return joven.Nutricionista;
        }

        public Medico ConsultarMedicoPediatra(int idJoven)
        {
            var joven =
                _appContext
                    .Jovenes
                    .Where(p => p.Id == idJoven)
                    .Include(p => p.Pediatra)
                    .FirstOrDefault();
            return joven.Pediatra;
        }

        public IEnumerable<PatronesCrecimiento> GetPatronesDeCrecimiento(int idJoven)
        {
            var joven =
                _appContext
                    .Jovenes
                    .Where(j => j.Id == idJoven)
                    .Include(j => j.PatronesCrecimientoJoven)
                    .FirstOrDefault();
            return joven.PatronesCrecimientoJoven;
        }

    }
}
