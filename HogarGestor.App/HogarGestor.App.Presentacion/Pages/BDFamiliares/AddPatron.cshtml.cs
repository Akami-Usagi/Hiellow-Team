using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDFamiliares
{
    public class AddPatronModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        [BindProperty]
        public PatronesCrecimiento patron {get;set;}
        [BindProperty]
        public Historia historia {get;set;}
        [BindProperty]
        public Joven joven {get;set;}
        [BindProperty]
        public List<PatronesCrecimiento> listaPatrones{get;set;}
        public AddPatronModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                
                return Page();
            }
        }

        public IActionResult OnPostSave(){
            historia = _RepoJoven.GetHistoriaJoven(joven.Id);
            if(historia == null){
                historia = new Historia{
                    Registro = "Inicial",
                    PatronCrecimiento = listaPatrones
                    };
                historia.PatronCrecimiento.Add(patron);
                historia = _RepoJoven.ToAssignHistoria(joven.Id, historia);
            }
            else{
                
                listaPatrones.Add(patron);
                historia.PatronCrecimiento = listaPatrones;
                historia = _RepoJoven.ToAssignHistoria(joven.Id, historia);
            }
            return RedirectToPage("./Index");
        }

    }
}
