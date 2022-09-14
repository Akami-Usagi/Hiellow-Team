using System.Security.AccessControl;
using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia{

    public interface IRepositorioJoven{
        IEnumerable<Joven> GetAllJovenes();
        Joven AddJoven(Joven joven);
        Joven UpdateJoven(Joven joven);
        void DeleteJoven(int IdJoven);
        Joven GetJoven(int IdJoven);
        //Joven ToAsignFamiliar(int IdJoven, Familiar familiar);
        Medico ToAsignNutricionista(int IdJoven, Medico nutricionista);
        Medico ToAsignPediatra(int IdJoven, Medico pediatra);
        IEnumerable<Joven> GetFiltro(string filtro);
    }
}