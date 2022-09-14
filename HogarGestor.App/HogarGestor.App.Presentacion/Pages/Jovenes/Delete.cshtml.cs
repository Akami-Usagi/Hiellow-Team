using System;
using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HogarGestor.App.Presentacion.Pages_Jovenes
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        [BindProperty]
        public Joven joven {get;set;}
        public DeleteModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJovenMemoria.Get(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
            
        }

        public IActionResult OnPostDelete(){
            _RepoJovenMemoria.Delete(joven.Id);
            return RedirectToPage("Index");            
        }
    }
}