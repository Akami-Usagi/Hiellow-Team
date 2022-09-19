using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using HogarGestor.App.Presentacion.Pages_BDJovenes;

namespace HogarGestor.App.Presentacion.Pages_BDFamiliares
{
    public class ListaSugerenciasModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        private readonly IRepositorioFamiliar _RepoFamiliar;
        [BindProperty]
        public Joven joven{get;set;}
        [BindProperty]
        public Historia historia{get;set;}
        [BindProperty]
        public Familiar familiar {get;set;}
        public IEnumerable<SugerenciaCuidado> listaSugerencias{get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}

        public ListaSugerenciasModel(IRepositorioJoven _RepoJoven, IRepositorioFamiliar _RepoFamiliar){
            this._RepoJoven = _RepoJoven;
            this._RepoFamiliar = _RepoFamiliar;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                historia = _RepoJoven.GetHistoriaJoven(joven.Id);
                familiar = _RepoJoven.ConsultarFamiliar(joven.Id);
                listaSugerencias = _RepoJoven.GetSugerenciasJoven(joven.Id);
                return Page();
            }
        }
    }
}
