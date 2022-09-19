using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using HogarGestor.App.Presentacion.Pages_BDJovenes;

namespace HogarGestor.App.Presentacion.Pages_BDMedicos
{
    public class ListaPatronesModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        private readonly IRepositorioMedico _RepoMedico;
        [BindProperty]
        public Joven joven{get;set;}
        [BindProperty]
        public Historia historia{get;set;}
        [BindProperty]
        public Medico medico {get;set;}
        public IEnumerable<PatronesCrecimiento> listaPatrones{get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        public ListaPatronesModel(IRepositorioJoven _RepoJoven, IRepositorioMedico _RepoMedico){
            this._RepoJoven = _RepoJoven;
            this._RepoMedico = _RepoMedico;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                historia = _RepoJoven.GetHistoriaJoven(joven.Id);
                medico = _RepoJoven.ConsultarMedico(joven.Id);                               
                listaPatrones = _RepoJoven.GetPatronesJoven(joven.Id);
                return Page();
            }
            
            
        }
    }
}