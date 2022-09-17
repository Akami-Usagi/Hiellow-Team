using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        [BindProperty]
        public Medico medico {get;set;}
        public DeleteModel(IRepositorioMedico _RepoMedico){
            this._RepoMedico = _RepoMedico;
        }
        public IActionResult OnGet(int Id)
        {
            medico = _RepoMedico.GetMedico(Id);
            if(medico == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
            
        }

        public IActionResult OnPostDelete(){
            _RepoMedico.DeleteMedico(medico.Id);
            return RedirectToPage("Index");            
        }
    }
}