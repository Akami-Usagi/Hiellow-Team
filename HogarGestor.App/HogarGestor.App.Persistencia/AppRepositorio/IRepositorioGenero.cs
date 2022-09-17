using System.Collections.Generic;
using HogarGestor.App.Dominio;
namespace HogarGestor.App.Persistencia
{
    public interface IRepositorioGenero
    {
         IEnumerable<Genero> GetAllGeneros();
    }
}