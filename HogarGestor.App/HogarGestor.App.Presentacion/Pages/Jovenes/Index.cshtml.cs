using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HogarGestor.App.Presentacion.Page_Jovenes
{
    public class IndexModel : PageModel
    {
       private readonly IRepositorioJovenMemoria _RepoJovenMemoria;

        public IEnumerable<Joven> Jovenes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GetFilter { get; set; }

        public IndexModel(IRepositorioJovenMemoria _RepoJovenMemoria)
        {
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }

        public void OnGet(string GetFilter)
        {
            Jovenes = _RepoJovenMemoria.GetFilter(GetFilter);
        }
    }
}
