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

        Familiar ToAssignFamiliar(int IdJoven, Familiar familiar);

        Medico ToAssignNutricionista(int IdJoven, Medico nutricionista);

        Medico ToAssignPediatra(int IdJoven, Medico pediatra);

        IEnumerable<Joven> GetFilter(string filtro);

        Medico ConsultarMedicoNutricionista(int idJoven);

        Medico ConsultarMedicoPediatra(int idJoven);

        IEnumerable<PatronesCrecimiento> GetPatronesDeCrecimiento(int idJoven);

        //IEnumerable<Joven> JovenMedico(int idJoven);
    }
}
