using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class JovenesAsignadosModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        

        public IEnumerable<Joven> Jovenes {get;set;}

        [BindProperty(SupportsGet = true)]
        public int GetFilter {get;set;}


        [BindProperty]
        public Medico Medico {get;set;}

        public JovenesAsignadosModel(IRepositorioMedico _RepoMedico){
            this._RepoMedico = _RepoMedico;
        }

        public void OnGet(int GetFilter)
        {
            //Medico = _RepoMedico.GetMedico(GetFilter);
            Jovenes = _RepoMedico.JovenesAsignadosPediatra(GetFilter);
            if(!Jovenes.Any()){
                Jovenes = _RepoMedico.JovenesAsignadosNutricionista(GetFilter);
            }
        }
    }
}
