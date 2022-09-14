using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDMedicos
{
    public class EditModel : PageModel
    {
       private readonly IRepositorioMedico _RepoMedico;
        [BindProperty]
        public Medico medico {get;set;}
        public EditModel(IRepositorioMedico _RepoMedico){
            this._RepoMedico = _RepoMedico;
        }
        public IActionResult OnGet(int Id)
        {
            medico = _RepoMedico.GetMedico(Id);
            if(medico == null){
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPostEdit(){
            medico = _RepoMedico.UpdateMedico(medico);
            return RedirectToPage("./index");
        }
    }
}
