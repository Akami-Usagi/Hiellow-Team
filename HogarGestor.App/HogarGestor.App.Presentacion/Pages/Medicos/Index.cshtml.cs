using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Medicos
{
    public class IndexModel : PageModel
    {

        private readonly IRepositorioMedicoMemoria _RepoMedicoMemoria;
        public IEnumerable<Medico> Medicos {get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        public IndexModel(IRepositorioMedicoMemoria _RepoMedicoMemoria){
            this._RepoMedicoMemoria = _RepoMedicoMemoria;
        }

        public void OnGet(string GetFilter){
            Medicos = _RepoMedicoMemoria.GetFiltro(GetFilter);
        }
        
    }
}
