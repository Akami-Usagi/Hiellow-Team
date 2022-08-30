using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioJoven
    {
        IEnumerable<Joven> GetAllPaciente();

        Joven AddPaciente(Joven joven);

        Joven UpdatePaciente(Joven joven);

        void DeletePaciente(int idJoven);

        Joven GetPaciente(int idJoven);
    }
}
