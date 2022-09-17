using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_BDJovenes
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        public Joven joven {get;set;}
        public Medico pediatra{get;set;}
        public Medico nutricionista{get;set;}
        public Familiar familiar{get;set;}
        public DetailsModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if (joven == null){
                return RedirectToPage("./NotFound");
            }
            else {
                if(_RepoJoven.ConsultarPediatra(Id) == null){
                    pediatra = new Medico{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.Pediatra = pediatra;
                }
                else{
                    joven.Pediatra=_RepoJoven.ConsultarPediatra(Id);
                }
                if(_RepoJoven.ConsultarNutricionista(Id) == null){
                    nutricionista = new Medico{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.Nutricionista = nutricionista;
                }
                else{
                    joven.Nutricionista = _RepoJoven.ConsultarNutricionista(Id);
                }
                if(_RepoJoven.ConsultarFamiliar(Id) == null){
                    familiar = new Familiar{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.FamiliarDesignado = familiar;
                }
                else{
                    joven.FamiliarDesignado = _RepoJoven.ConsultarFamiliar(Id);
                }
                return Page();
            }
        }
    }
}
