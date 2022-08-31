using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Persistencia
{
    /*public class RepositorioJoven : IRepositorioJoven
    {
        private readonly AppContext _appContext;

        public RepositorioJoven(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public Joven AddJoven(Joven joven)
        {
            var jovenEncontrado = _appContext.Jovenes.Add(joven);
            _appContext.SaveChange();
            return pacienteAdicionado;
        }

        public void DeleteJoven(int idJoven)
        {
            var jovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(p => p.id == idJoven);

            if (jovenEncontrado == null)
            {
                return;
            }

            _appContext.Jovenes.Remove (pacienteEncontrado);
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

        public Joven UpdateJoven(Joven joven)
        {
            var jovenEncontrado =
                _appContext.Jovenes.FirstOrDefault(p => p.id == joven.id);

            if (pacienteEncontrado != null)
            {
                jovenEncontrado.Nombre = joven.Nombre;
                jovenEncontrado.Apellidos = joven.Apellidos;
                jovenEncontrado.telefono = joven.Telefono;
                jovenEncontrado.Documento = joven.Documento;
                jovenEncontrado.DocumentoTipo = joven.TipoDocumento;
                jovenEncontrado.Genero = joven.Genero;

                jovenEncontrado.Direccion = joven.Direccion;
                jovenEncontrado.Latitud = joven.Latitud;
                jovenEncontrado.longitud = joven.longitud;
                jovenEncontrado.Ciudad = joven.Ciudad;
                jovenEncontrado.FechaNacimiento = joven.FechaNacimiento;
                jovenEncontrado.FamiliarDesignado = joven.FamiliarDesignado;
                jovenEncontrado.Nutricionista = joven.Nutricionista;
                jovenEncontrado.Pediatra = joven.Pediatra;
                _appContext.SaveChanges();
                return jovenEncontrado;
            }
        }
    }*/
}


