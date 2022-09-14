using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDJovenes
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        [BindProperty]
        public Joven joven {get;set;}
        public EditModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPostEdit(){
            joven = _RepoJoven.UpdateJoven(joven);
            return RedirectToPage("./index");
        }
    }
}
