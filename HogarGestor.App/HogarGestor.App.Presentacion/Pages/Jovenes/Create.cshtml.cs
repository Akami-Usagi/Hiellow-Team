using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Jovenes
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        [BindProperty]
        public Joven joven {get;set;}
        public CreateModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            joven = _RepoJovenMemoria.Add(joven);
            return RedirectToPage("Index");
        }

    }
}
