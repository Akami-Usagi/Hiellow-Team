using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDJovenes
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        [BindProperty]
        public Joven joven {get;set;}
        public CreateModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            joven = _RepoJoven.AddJoven(joven);
            return RedirectToPage("Index");
        }

    }
}
