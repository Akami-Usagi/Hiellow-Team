using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_Jovenes
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        public Joven joven {get;set;}
        public Medico pediatra{get;set;}
        public DetailsModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJovenMemoria.Get(Id);
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
                return Page();
            }
        }
    }
}
