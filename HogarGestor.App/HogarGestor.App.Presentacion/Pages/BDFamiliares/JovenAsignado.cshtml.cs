using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Presentacion.Pages_BDFamiliares
{
    public class JovenAsignadoModel : PageModel
    {
        private readonly IRepositorioFamiliar _RepoFamiliar;
        public IEnumerable<Joven> Jovenes {get;set;}
        [BindProperty(SupportsGet = true)]
        public int GetFilter {get;set;}
        [BindProperty]
        public Familiar familiar {get;set;}
        public JovenAsignadoModel(IRepositorioFamiliar _RepoFamiliar){
            this._RepoFamiliar = _RepoFamiliar;
        }
        public void OnGet(int GetFilter)
        {
            //familiar = _RepoFamiliar.GetFamiliar(Id);
            Jovenes = _RepoFamiliar.JovenesAsignadosFamiliar(GetFilter);
        }
    }
}
