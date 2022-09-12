using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_Jovenes
{
    public class ToAssignMedicoModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria _RepoMedicoMemoria;
        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        public IEnumerable<Medico> Medicos {get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        [BindProperty]
        public int IdMedico {get;set;}
        [BindProperty]
        public Medico medico {get;set;}
        [BindProperty]
        public Joven joven {get;set;}
        public ToAssignMedicoModel(IRepositorioMedicoMemoria _RepoMedicoMemoria, IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoMedicoMemoria = _RepoMedicoMemoria;
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }
        public IActionResult OnGet(int id)
        {
            Medicos = _RepoMedicoMemoria.GetAll();
            joven = _RepoJovenMemoria.Get(id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
        }
        public IActionResult OnPostAssing(int IdMedico){
            medico = _RepoMedicoMemoria.Get(IdMedico);
            medico = _RepoJovenMemoria.ToAssignMedicoPediatra(joven.Id, medico);
            return RedirectToPage("./index");
        }
    }
}
