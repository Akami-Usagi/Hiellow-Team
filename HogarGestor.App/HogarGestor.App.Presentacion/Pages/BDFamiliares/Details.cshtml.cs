using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages_BDFamiliares
{
    public class DetailsModel : PageModel
    {
       private readonly IRepositorioFamiliar _RepoFamiliar;
        public Familiar familiar {get;set;}
        public DetailsModel(IRepositorioFamiliar _RepoFamiliar){
            this._RepoFamiliar = _RepoFamiliar;
        }
        public IActionResult OnGet(int Id)
        {
            familiar = _RepoFamiliar.GetFamiliar(Id);
            if (familiar == null){
                return RedirectToPage(",/NotFound");
            }
            else {
                return Page();
            }
        }
    }

}
