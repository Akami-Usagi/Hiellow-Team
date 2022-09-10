using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
namespace HogarGestor.App.Presentacion.Pages_Medicos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria _RepoMedicoMemoria;
        public Medico medico {get;set;}
        public DetailsModel(IRepositorioMedicoMemoria _RepoMedicoMemoria){
            this._RepoMedicoMemoria = _RepoMedicoMemoria;
        }
        public IActionResult OnGet(int Id)
        {
            medico = _RepoMedicoMemoria.Get(Id);
            if (medico == null){
                return RedirectToPage(",/NotFound");
            }
            else {
                return Page();
            }
        }
    }
}
