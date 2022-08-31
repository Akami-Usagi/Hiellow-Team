using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioJoven
    {
        IEnumerable<Joven> GetAllJovenes();

        Joven AddJoven(Joven joven);

        Joven UpdateJoven(Joven joven);

        void DeleteJoven(int idJoven);

        Joven GetJoven(int idJoven);
    }
}
