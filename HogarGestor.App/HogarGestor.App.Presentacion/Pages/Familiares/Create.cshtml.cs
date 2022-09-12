using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Familiares
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioFamiliarMemoria _RepoFamiliarMemoria;
        [BindProperty]
        public Familiar familiar {get;set;}
        public CreateModel(IRepositorioFamiliarMemoria _RepoFamiliarMemoria){
            this._RepoFamiliarMemoria = _RepoFamiliarMemoria;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            familiar = _RepoFamiliarMemoria.Add(familiar);
            return RedirectToPage("Index");
        }
    }

}