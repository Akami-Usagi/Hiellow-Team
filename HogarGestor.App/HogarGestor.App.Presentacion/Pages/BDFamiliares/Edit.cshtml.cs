using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Presentacion.Pages_BDFamiliares
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioFamiliar _RepoFamiliar;
        private readonly IRepositorioGenero _RepoGenero;

        [BindProperty]
        public Familiar familiar {get;set;}

        public IEnumerable<SelectListItem> Options { get; set; }

        public EditModel(IRepositorioFamiliar _RepoFamiliar, IRepositorioGenero _RepoGenero){
            this._RepoFamiliar = _RepoFamiliar;
            this._RepoGenero = _RepoGenero;
        }
        public IActionResult OnGet(int Id)
        {

            Options = _RepoGenero.GetAllGeneros().Select(a =>new SelectListItem(){
                Text =  a.Nombre,
                Value = a.Id.ToString()
            });

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
