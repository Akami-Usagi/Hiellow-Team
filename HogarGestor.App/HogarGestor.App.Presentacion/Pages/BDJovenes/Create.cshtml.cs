using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Presentacion.Pages_BDJovenes
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        private readonly IRepositorioGenero _RepoGenero;
        
        [BindProperty]
        public Joven joven {get;set;}

        public IEnumerable<SelectListItem> Options { get; set; }
        public CreateModel(IRepositorioJoven _RepoJoven, IRepositorioGenero _RepoGenero){
            this._RepoJoven = _RepoJoven;
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
            joven = _RepoJoven.AddJoven(joven);
            return RedirectToPage("Index");
        }

    }
}