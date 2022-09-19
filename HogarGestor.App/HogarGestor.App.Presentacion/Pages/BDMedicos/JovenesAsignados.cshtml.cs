using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDMedicos
{
    public class JovenesAsignadosModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        public IEnumerable<Joven> Jovenes {get;set;}
        [BindProperty(SupportsGet = true)]
        
        public int GetFilter {get;set;}
        [BindProperty]
        public Medico medico {get;set;}
        public JovenesAsignadosModel(IRepositorioMedico _RepoMedico){
            this._RepoMedico = _RepoMedico;
        }
        public void OnGet(int Id)
        {
            medico = _RepoMedico.GetMedico(Id);
            Jovenes = _RepoMedico.JovenesAsignadosPediatra(medico.Id);
            if(!Jovenes.Any()){
                Jovenes = _RepoMedico.JovenesAsignadosNutricionista(medico.Id);
            }
        }
    }
}
