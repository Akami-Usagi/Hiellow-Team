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
        Familiar ToAssignFamiliar(int IdJoven, Familiar familiar);
        Medico ToAssignNutricionista(int IdJoven, Medico nutricionista);
        Medico ToAssignPediatra(int IdJoven, Medico pediatra);
        IEnumerable<Joven> GetFiltro(string filtro);
        Medico ConsultarPediatra(int IdJoven);
        Medico ConsultarNutricionista(int IdJoven);
        Medico ConsultarMedico(int IdJoven);
        Familiar ConsultarFamiliar(int IdJoven);
        Historia GetHistoriaJoven(int IdJoven);
        Historia ToAssignHistoria(int IdJoven, Historia historia);
        IEnumerable<PatronesCrecimiento> GetPatronesJoven(int IdJoven);
        IEnumerable<SugerenciaCuidado> GetSugerenciasJoven(int IdJoven);
       
    }
}