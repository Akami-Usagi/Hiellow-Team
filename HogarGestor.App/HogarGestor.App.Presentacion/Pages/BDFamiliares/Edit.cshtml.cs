using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDFamiliares
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioFamiliar _RepoFamiliar;
        [BindProperty]
        public Familiar familiar {get;set;}
        public EditModel(IRepositorioFamiliar _RepoFamiliar){
            this._RepoFamiliar = _RepoFamiliar;
        }
        public IActionResult OnGet(int Id)
        {
            familiar = _RepoFamiliar.GetFamiliar(Id);
            if(familiar == null){
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPostEdit(){
            familiar = _RepoFamiliar.UpdateFamiliar(familiar);
            return RedirectToPage("./Index");
        }
    }
}
