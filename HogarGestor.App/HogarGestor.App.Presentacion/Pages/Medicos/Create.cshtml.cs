using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Medicos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria _RepoMedicoMemoria;
        [BindProperty]
        public Medico medico {get;set;}
        public CreateModel(IRepositorioMedicoMemoria _RepoMedicoMemoria){
            this._RepoMedicoMemoria = _RepoMedicoMemoria;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            medico = _RepoMedicoMemoria.Add(medico);
            return RedirectToPage("Index");
        }
    }
}