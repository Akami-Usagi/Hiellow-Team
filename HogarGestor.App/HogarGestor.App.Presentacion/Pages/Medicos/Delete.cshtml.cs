using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Medicos
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria _RepoMedicoMemoria;
        public Medico medico {get;set;}
        public DeleteModel(IRepositorioMedicoMemoria _RepoMedicoMemoria){
            this._RepoMedicoMemoria = _RepoMedicoMemoria;
        }
        public ActionResult OnGet(int Id)
        {
            medico = _RepoMedicoMemoria.Get(Id);
            if (medico == null){
                return RedirectToPage(",/NotFound");
            }
            else {
                _RepoMedicoMemoria.Delete(medico.Id);
                return RedirectToPage("Index");
            }
        }
    }
}
