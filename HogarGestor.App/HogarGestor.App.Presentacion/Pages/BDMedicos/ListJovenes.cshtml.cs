using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class ListJovenesModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;

        public IEnumerable<Joven> Pacientes {get; set;}

        [BindProperty(SupportsGet=true)]
        public int GetFilters{get; set;}

        public ListJovenesModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven=_RepoJoven;
        }

        public void OnGet(int GetFilter)
        {
            //Pacientes = _RepoJoven.PacienteMedico(GetFilter);
        }
    }
}
