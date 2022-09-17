using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;

        public IEnumerable<Medico> Medicos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}

        public IndexModel(IRepositorioMedico _RepoMedico)
        {
            this._RepoMedico = _RepoMedico;
        }

        public void OnGet()
        {
           Medicos = _RepoMedico.GetFilter(GetFilter);
        }
    }
}
