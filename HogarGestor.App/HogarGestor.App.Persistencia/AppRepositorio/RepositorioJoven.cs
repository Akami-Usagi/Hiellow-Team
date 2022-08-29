using System;
using System.Collections.Generic;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioJoven : IRepositorioJoven
    {
        private readonly AppContext _appContext;

        public RepositorioJoven(AppContext appContext){
            this._appContext = appContext;
        }
        

        public IEnumerable<Joven> GetAllJoven()
        {
            return _appContext.Jovens;
        }

        public Joven AddJoven(Joven joven)
        {
            var jovenAdicionado = _appContext.Jovens.Add(joven);
            _appContext.SaveChanges();
            return jovenAdicionado.Entity;
        }

        public Joven UpdateJoven(Joven joven)
        {
            //var jovenEncontrado = _appContext.Jovens.FirstOrDefault(j=>j.Id)
            throw new NotImplementedException();
        }

        public void DeleteJoven(int idJoven)
        {
            throw new NotImplementedException();
        }

        public Joven GetJoven(int idJoven)
        {
            throw new NotImplementedException();
        }
    }
}
