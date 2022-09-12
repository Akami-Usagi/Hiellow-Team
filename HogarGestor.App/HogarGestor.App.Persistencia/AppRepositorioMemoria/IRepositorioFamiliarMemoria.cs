
using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioFamiliarMemoria
    {
        IEnumerable<Familiar> GetAll();

        Familiar Add(Familiar familiar);

        Familiar Update(Familiar familiar);

        void Delete(int familiarId);

        Familiar Get(int familiarId);

        IEnumerable<Familiar> GetFilter(string filtro);
    }
}