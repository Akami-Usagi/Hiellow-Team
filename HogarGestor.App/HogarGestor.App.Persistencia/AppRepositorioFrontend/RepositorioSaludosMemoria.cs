using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> Saludos;

        public RepositorioSaludosMemoria(){
            Saludos = new List<Saludo>(){
                new Saludo{Id = 1, EnEspanol = "Buenos Dias", EnIngles = "Good Morning", EnItaliano = "Bongiorno"},
                new Saludo{Id = 2, EnEspanol = "Buenas Tardes", EnIngles = "Good Afternoon", EnItaliano = "Buon Pomeriggio"},
                new Saludo{Id = 3, EnEspanol = "Buenas Noches", EnIngles = "Good Evening", EnItaliano = "Bouna notte"}
            };
        }
        public IEnumerable<Saludo> GetAll()
        {
            return Saludos;
        }

        public IEnumerable<Saludo> GetSaludoPorFiltro(string Filtro)
        {
            throw new NotImplementedException();
        }

        public Saludo GetSaludoPorId(int saludoId)
        {
            return Saludos.SingleOrDefault(s => s.Id == saludoId);
        }
    }
}