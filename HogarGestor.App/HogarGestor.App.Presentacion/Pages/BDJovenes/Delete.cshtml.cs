using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_BDJovenes
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        [BindProperty]
        public Joven joven {get;set;}
        public DeleteModel(IRepositorioJoven _RepoJoven){
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

        public IActionResult OnPostDelete(){
            _RepoJoven.DeleteJoven(joven.Id);
            return RedirectToPage("index");            
        }
    }
}