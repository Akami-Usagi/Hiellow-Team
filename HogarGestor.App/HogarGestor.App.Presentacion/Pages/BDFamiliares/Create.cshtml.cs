using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_BDFamiliares
{
    public class CreateModel : PageModel
    {

        private readonly IRepositorioFamiliar _RepoFamiliar;
        [BindProperty]
        public Familiar familiar {get;set;}
        public CreateModel(IRepositorioFamiliar _RepoFamiliar){
            this._RepoFamiliar = _RepoFamiliar;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            familiar = _RepoFamiliar.AddFamiliar(familiar);
            return RedirectToPage("Index");
        }
    }

}
