using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioMedicoMemoria
    {
        IEnumerable<Medico> GetAll();
        Medico Add(Medico medico);
        Medico Update(Medico medico);
        void Delete(int IdMedico);
        Medico Get(int IdMedico);
        IEnumerable<Medico> GetFilter(string filtro);
    }
}