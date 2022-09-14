using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Presentacion.Page_Jovenes
{
    public class EditarJovenModel : PageModel
    {
       private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        [BindProperty]
        public Joven joven {get;set;}
        public EditarJovenModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }


        public IActionResult OnGet(int Id)
        {
            joven = _RepoJovenMemoria.Get(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPostEdit(){
            joven = _RepoJovenMemoria.Update(joven);
            return RedirectToPage("Index");
        }
    }
}