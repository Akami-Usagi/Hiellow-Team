using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioJovenMemoria
    {
        IEnumerable<Joven> GetAll();

        Joven Add(Joven joven);

        Joven Update(Joven joven);

        void Delete(int jovenId);

        Joven Get(int jovenId);

        IEnumerable<Joven> GetFilter(string filtro);

        Medico ToAssignMedicoPediatra(int IdJoven, Medico Pediatra);

        Medico ToAssignMedicoNutricionista(int IdJoven, Medico Nutricionista);
    }
}
