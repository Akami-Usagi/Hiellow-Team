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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioGenero _RepoGenero;

        private readonly IRepositorioFamiliar _RepoFamiliar;
        [BindProperty]
        public Familiar familiar {get;set;}

        public IEnumerable<SelectListItem> Options { get; set; }
        public CreateModel(
            IRepositorioFamiliar _RepoFamiliar,
            IRepositorioGenero _RepoGenero
        )
        {
            this._RepoFamiliar = _RepoFamiliar;
            this._RepoGenero = _RepoGenero;
        }

        public void OnGet()
        {
            Options = _RepoGenero.GetAllGeneros().Select(a =>new SelectListItem(){
                Text =  a.Nombre,
                Value = a.Id.ToString()
            });
        }

        public IActionResult OnPostSave(){
            familiar = _RepoFamiliar.AddFamiliar(familiar);
            return RedirectToPage("Index");
        }
    }
}
