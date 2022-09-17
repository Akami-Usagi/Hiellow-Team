
using System.Linq;
using HogarGestor.App.Dominio;
namespace HogarGestor.App.Persistencia
{
    public class RepositorioGenero : IRepositorioGenero
    {
        private readonly AppContext _appContext;
        public RepositorioGenero(AppContext appContext){
            this._appContext = appContext;
        }
        public IEnumerable<Genero> GetAllGeneros(){
            return _appContext.Generos;
        }
    }
}