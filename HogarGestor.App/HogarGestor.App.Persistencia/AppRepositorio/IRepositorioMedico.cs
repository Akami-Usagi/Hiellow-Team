using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioMedico
    {
        IEnumerable<Medico> GetAllMedico();

        Medico AddMedico(Medico medico);

        Medico UpdateMedico(Medico medico);

        void DeleteMedico(int idMedico);

        Medico GetMedico(int idMedico);

        IEnumerable<Medico> GetAllPediatras(Especialidad especialidad);

        IEnumerable<Medico> GetAllNutricionistas(Especialidad especialidad);

        IEnumerable<Medico> GetFilter(string filtro);
    }
}
