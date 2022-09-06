using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia{
    public interface IRepositorioJovenMemoria{

        IEnumerable<Joven> GetAll();
        Joven Add(Joven joven);
        Joven Update(Joven joven);
        void Delete(string DocumentoJoven);
        Joven Get(string DocumentoJoven);
        
    }
}