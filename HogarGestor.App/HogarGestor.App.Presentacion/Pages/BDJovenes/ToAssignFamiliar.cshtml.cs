using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarHestor.App.Presentacion.Pages_BDJovenes
{
    public class ToAssignFamiliarModel : PageModel
    {
        private readonly IRepositorioFamiliar _RepoFamiliar;
        private readonly IRepositorioJoven _RepoJoven;
        public IEnumerable<Familiar> Familiares {get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        [BindProperty]
        public int IdFamiliar {get;set;}
        [BindProperty]
        public Familiar familiar {get;set;}
        [BindProperty]
        public Joven joven {get;set;}
        public ToAssignFamiliarModel(IRepositorioFamiliar _RepoFamiliar, IRepositorioJoven _RepoJoven){
            this._RepoFamiliar = _RepoFamiliar;
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int id)
        {
            Familiares = _RepoFamiliar.GetAllFamiliares();
            joven = _RepoJoven.GetJoven(id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
        }
        
        public IActionResult OnPostToAssign(int IdFamiliar){
            familiar = _RepoFamiliar.GetFamiliar(IdFamiliar);
            familiar = _RepoJoven.ToAssignFamiliar(joven.Id, familiar);
            return RedirectToPage("index");
        }
    }
}
