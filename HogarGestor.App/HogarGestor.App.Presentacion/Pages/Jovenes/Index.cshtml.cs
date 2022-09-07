using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Page_Jovenes
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        public IEnumerable<Joven> Jovenes {get;set;}

        public IndexModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }
        public void OnGet()
        {
             Jovenes = _RepoJovenMemoria.GetAll();
        }
    }
}
