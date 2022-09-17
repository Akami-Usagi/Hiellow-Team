using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Presentacion.Pages_BDFamiliares
{
    public class IndexModel : PageModel
    {
       private readonly IRepositorioFamiliar _RepoFamiliar;
        public IEnumerable<Familiar> Familiares {get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}

        public IndexModel(IRepositorioFamiliar _RepoFamiliar){
            this._RepoFamiliar = _RepoFamiliar;
        }
        
        public void OnGet(string GetFilter){
            Familiares = _RepoFamiliar.GetFilter(GetFilter);
        }

    }
}