using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDJovenes
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        public IEnumerable<Joven> Jovenes {get;set;}
        //[BindProperty(SupportsGet = true)]
        //public string GetFilter {get;set;}
        public IndexModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }

        public void OnGet(){
            Jovenes = _RepoJoven.GetAllJovenes();
        }
    }
}
