using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;


namespace HogarGestor.App.Presentacion.Pages_BDJovenes
{
    public class ToAssignPediatraModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;
        private readonly IRepositorioJoven _RepoJoven;
        public IEnumerable<Medico> Medicos {get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        [BindProperty]
        public int IdMedico {get;set;}
        [BindProperty]
        public Medico medico {get;set;}
        [BindProperty]
        public Joven joven {get;set;}
        public ToAssignPediatraModel(IRepositorioMedico _RepoMedico, IRepositorioJoven _RepoJoven){
            this._RepoMedico = _RepoMedico;
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int id)
        {
            Medicos = _RepoMedico.GetAllPediatras(Especialidad.Pediatria);
            joven = _RepoJoven.GetJoven(id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
        }
        
        public IActionResult OnPostToAssign(int IdMedico){
            medico = _RepoMedico.GetMedico(IdMedico);
            medico = _RepoJoven.ToAssignPediatra(joven.Id, medico);
            return RedirectToPage("index");
        }
    }
}
