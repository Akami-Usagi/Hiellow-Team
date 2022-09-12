using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_Jovenes
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        public Joven joven {get;set;}
        public DeleteModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }
        public ActionResult OnGet(int Id)
        {
            joven = _RepoJovenMemoria.Get(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPostDelete(){
            joven = _RepoJovenMemoria.Get(joven.Id);
            
                _RepoJovenMemoria.Delete(joven.Id);
                return RedirectToPage("index");
            
        }
    }
}
