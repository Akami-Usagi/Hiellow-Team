using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioFamiliarMemoria
    {
        IEnumerable<Familiar> GetAll();
        Familiar Add(Familiar familiar);
        Familiar Update(Familiar familiar);
        void Delete(int IdFamiliar);
        Familiar Get(int IdFamiliar);
        IEnumerable<Familiar> GetFiltro(string filtro);
    }
}