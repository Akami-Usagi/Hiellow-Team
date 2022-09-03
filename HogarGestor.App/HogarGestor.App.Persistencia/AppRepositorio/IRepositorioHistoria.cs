using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistoria();

        Historia AddHistoria(Historia historia);

        Historia UpdateHistoria(Historia historia);

        Historia DeleteHistoria(int idHistoria);
    }
}
