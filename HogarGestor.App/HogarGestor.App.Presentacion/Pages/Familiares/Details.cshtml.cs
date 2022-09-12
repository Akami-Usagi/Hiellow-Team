using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Familiares
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioFamiliarMemoria _RepoFamiliarMemoria;
        public Familiar familiar {get;set;}
        public DetailsModel(IRepositorioFamiliarMemoria _RepoFamiliarMemoria){
            this._RepoFamiliarMemoria = _RepoFamiliarMemoria;
        }
        public IActionResult OnGet(int Id)
        {
            familiar = _RepoFamiliarMemoria.Get(Id);
            if (familiar == null){
                return RedirectToPage(",/NotFound");
            }
            else {
                return Page();
            }
        }
    }

}