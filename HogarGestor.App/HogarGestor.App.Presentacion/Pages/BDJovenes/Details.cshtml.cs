using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Presentacion.Pages_BDJovenes
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
                if(_RepoJoven.ConsultarMedicoNutricionista(Id)==null){
                    nutricionista = new Medico{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.Nutricionista = nutricionista;
                }else{
                    joven.Nutricionista = _RepoJoven.ConsultarMedicoNutricionista(Id);
                }

                if(_RepoJoven.ConsultarMedicoPediatra(Id)==null){
                    pediatra = new Medico{
                        Nombre = "SIN ASIGNAR"
                    };
                    joven.Pediatra = pediatra;
                }else{
                    joven.Pediatra = _RepoJoven.ConsultarMedicoPediatra(Id);
                }
                return Page();
            }
        }
    }
}