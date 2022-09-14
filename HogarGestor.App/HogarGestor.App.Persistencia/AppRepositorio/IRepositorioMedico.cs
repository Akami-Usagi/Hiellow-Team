using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioMedico
    {
        IEnumerable<Medico> GetAllMedicos();
        Medico AddMedico(Medico medico);
        Medico UpdateMedico(Medico medico);
        void DeleteMedico(int IdMedico);
        Medico GetMedico(int IdMedico);
        IEnumerable<Medico> GetAllPediatras(Especialidad especialidad);
        IEnumerable<Medico> GetAllNutricionistas(Especialidad especialidad);
    }
}