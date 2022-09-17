using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        private readonly IRepositorioGenero _RepoGenero;
        [BindProperty]
        public Medico medico {get;set;}

        public IEnumerable<SelectListItem> Options { get; set; }
        public CreateModel(IRepositorioMedico _RepoMedico, IRepositorioGenero _RepoGenero){
            this._RepoMedico = _RepoMedico;
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
            medico = _RepoMedico.AddMedico(medico);
            return RedirectToPage("Index");
        }


        

       
    }
}