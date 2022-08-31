using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var jovenEncontrado = _appContext.Jovenes.Add(joven);
            _appContext.SaveChanges();
            return jovenEncontrado;
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
                jovenEncontrado.Nutricionista = joven.Nutricionista;
                jovenEncontrado.Pediatra = joven.Pediatra;
                _appContext.SaveChanges();
                return jovenEncontrado;
            }
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
            _appContext.SaveChange();
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

/*

public string Direccion { get; set; }

        public float Latitud { get; set; }

        public float longitud { get; set; }

        public string Ciudad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Familiar Familiar { get; set; }

        public Medico Pediatra { get; set; }

        public Medico Nutricionista { get; set; }

        public List<Historia> HistoriaJoven { get; set; }

        public List<PatronesCrecimiento> PatronesCrecimiento { get; set; }

*/
