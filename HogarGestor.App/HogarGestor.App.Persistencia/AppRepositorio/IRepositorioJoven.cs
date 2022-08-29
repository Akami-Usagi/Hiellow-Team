using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioJoven
    {
        IEnumerable<Joven> GetAllJoven();

        Joven AddJoven(Joven joven);

        Joven UpdateJoven(Joven joven);

        void DeleteJoven(int idJoven);

        Joven GetJoven(int idJoven);
    }
}
