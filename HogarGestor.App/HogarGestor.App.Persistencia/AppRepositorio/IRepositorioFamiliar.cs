using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioFamiliar
    {
        IEnumerable<Familiar> GetAllFamiliares();
        Familiar AddFamiliar(Familiar familiar);
        Familiar UpdateFamiliar(Familiar familiar);
        void DeleteFamiliar(string DocumentoFamiliar);
        Familiar GetFamiliar(string DocumentoFamiliar);
    }
}