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
                if(joven.Pediatra == null){
                    pediatra = new Medico{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.Pediatra = pediatra;
                }
                if(joven.Nutricionista == null){
                    nutricionista = new Medico{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.Nutricionista = nutricionista;
                }
                if(joven.FamiliarDesignado == null){
                    familiar = new Familiar{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.FamiliarDesignado = familiar;
                }
                return Page();
            }
        }
    }
}
