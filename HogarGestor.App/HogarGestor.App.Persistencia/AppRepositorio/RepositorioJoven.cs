using System;
using System.Collections.Generic;
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
            this._appContext = appContext;
        }

        public IEnumerable<Joven> GetAllPaciente()
        {
            return _appContext.Jovenes;
        }

        public Joven AddPaciente(Joven joven)
        {
            var pacienteAdicionado = _appContext.Jovenes.Add(joven);
            _appContext.SaveChange();
            return pacienteAdicionado;
        }

        public Joven UpdatePaciente(Joven joven)
        {
            var pacienteEncontrado =
                _appContext.Jovenes.FirstOrDefault(p => p.id == joven.id);

            if (pacienteEncontrado != null)
            {
                
            }
        }

        public void DeletePaciente(int idJoven)
        {
            var pacienteEncontrado =
                _appContext.Jovenes.FirstOrDefault(p => p.id == idJoven);

            if (!pacienteEncontrado)
            {
                return;
            }

            _appContext.Jovenes.Remove (pacienteEncontrado);
            _appContext.SaveChange();
        }

        public Joven GetPaciente(int idJoven)
        {
            return _appContext.Jovenes.FirstOrDefault(p => p.id == idJoven);
        }
    }
}
