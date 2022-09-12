using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace HogarGestor.App.Persistencia
{
    public class RepositorioJovenMemoria : IRepositorioJovenMemoria
    {
        List<Joven> Jovenes;

        public RepositorioJovenMemoria()
        {
            Jovenes =
                new List<Joven>()
                {
                    new Joven {
                        Id = 1,
                        Nombre = "Camilo",
                        Apellido = "Arango",
                        Documento = "1115066671",
                        TipoDocumentoId = 1,
                        Telefono = "3103565058",
                        Direccion = "Calle 7 # 12-34",
                        Ciudad = "Buga",
                        GeneroId = 1,
                        FechaNacimiento = new DateTime(1987, 06, 07)
                    },
                    new Joven {
                        Id = 2,
                        Nombre = "Paola",
                        Apellido = "Blandon",
                        Documento = "38878362",
                        TipoDocumentoId = 1,
                        Telefono = "3156661050",
                        Direccion = "Calle 8 # 11-19",
                        Ciudad = "Buga",
                        GeneroId = 2,
                        FechaNacimiento = new DateTime(1975, 12, 12)
                    },
                    new Joven {
                        Id = 3,
                        Nombre = "Akemi",
                        Apellido = "Arango",
                        Documento = "1112406770",
                        TipoDocumentoId = 1,
                        Telefono = "3105325321",
                        Direccion = "Calle 7 # 12-34",
                        Ciudad = "Buga",
                        GeneroId = 1,
                        FechaNacimiento = new DateTime(2014, 02, 08)
                    }
                };
        }

        public Joven Add(Joven joven)
        {
            joven.Id = Jovenes.Max(p => p.Id) + 1;
            Jovenes.Add (joven);
            return joven;
        }

        public void Delete(int jovenId)
        {
            Joven joven = Jovenes.SingleOrDefault(j => j.Id == jovenId);
            Jovenes.Remove(joven);
        }

        public Joven Get(int jovenId)
        {
            return Jovenes.SingleOrDefault(j => j.Id == jovenId);
        }

        public IEnumerable<Joven> GetAll()
        {
            return Jovenes;
        }

        public Joven Update(Joven joven)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Joven> GetFilter(string filtro = null)
        {
            var Jovenes = GetAll();
            if (Jovenes != null)
            {
                if (!String.IsNullOrEmpty(filtro))
                {
                    Jovenes = Jovenes.Where(p => p.Documento.Contains(filtro));
                }
            }

            return Jovenes;
        }
    }
}
