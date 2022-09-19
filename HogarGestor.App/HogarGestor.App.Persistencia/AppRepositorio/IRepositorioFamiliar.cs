using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioFamiliar
    {
        IEnumerable<Familiar> GetAllFamiliar();

        Familiar AddFamiliar(Familiar familiar);

        Familiar UpdateFamiliar(Familiar familiar);

        void DeleteFamiliar(int idFamiliar);

        Familiar GetFamiliar(int idFamiliar);

        IEnumerable<Familiar> GetFilter(string filtro);

        IEnumerable<Joven> JovenesAsignadosFamiliar(int IdFamiliar);
        
    }
}
