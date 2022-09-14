using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
namespace HogarGestor.App.Presentacion.Pages_BDMedicos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        [BindProperty]
        public Medico medico {get;set;}
        public CreateModel(IRepositorioMedico _RepoMedico){
            this._RepoMedico = _RepoMedico;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            medico = _RepoMedico.AddMedico(medico);
            return RedirectToPage("Index");
        }
    }
}
