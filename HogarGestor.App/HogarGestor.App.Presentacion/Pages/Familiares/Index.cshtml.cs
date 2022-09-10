using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using HogarGestor.App.Presentacion.Pages_Jovenes;

namespace HogarGestor.App.Presentacion.Pages_Familiares
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioFamiliarMemoria _RepoFamiliarMemoria;
        public IEnumerable<Familiar> Familiares {get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        public IndexModel(IRepositorioFamiliarMemoria _RepoFamiliarMemoria){
            this._RepoFamiliarMemoria = _RepoFamiliarMemoria;
        }
        
        public void OnGet(string GetFilter){
            Familiares = _RepoFamiliarMemoria.GetFiltro(GetFilter);
        }

    }
}
