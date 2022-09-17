using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages_BDFamiliares
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioFamiliar _RepoFamiliar;
        [BindProperty]
        public Familiar familiar {get;set;}
        public DeleteModel(IRepositorioFamiliar _RepoFamiliar){
            this._RepoFamiliar = _RepoFamiliar;
        }
        public IActionResult OnGet(int Id)
        {
            familiar = _RepoFamiliar.GetFamiliar(Id);
            if(familiar == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
            
        }

        public IActionResult OnPostDelete(){
            _RepoFamiliar.DeleteFamiliar(familiar.Id);
            return RedirectToPage("index");            
        }
    }
}
