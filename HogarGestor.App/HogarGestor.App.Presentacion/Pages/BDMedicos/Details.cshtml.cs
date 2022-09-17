using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        public Medico medico {get;set;}
        public DetailsModel(IRepositorioMedico _RepoMedico){
            this._RepoMedico = _RepoMedico;
        }
        public IActionResult OnGet(int Id)
        {
            medico = _RepoMedico.GetMedico(Id);
            if (medico == null){
                return RedirectToPage(",/NotFound");
            }
            else {
                return Page();
            }
        }
    }
}