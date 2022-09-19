using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HogarGestor.App.Presentacion.Pages_BDMedicos
{
    public class ListaPatronesModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        private readonly IRepositorioMedico _RepoMedico;
        [BindProperty]
        public Joven joven{get;set;}
        [BindProperty]
        public Historia historia{get;set;}
        [BindProperty]
       // public List<PatronesCrecimiento> listaPatrones{get;set;}
       public Medico medico {get;set;}
        public IEnumerable<PatronesCrecimiento> listaPatrones{get;set;}
        [BindProperty(SupportsGet = true)]
        public string GetFilter {get;set;}
        public ListaPatronesModel(IRepositorioJoven _RepoJoven, IRepositorioMedico _RepoMedico){
            this._RepoJoven = _RepoJoven;
            this._RepoMedico = _RepoMedico;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            medico = _RepoJoven.ConsultarPediatra(joven.Id);
            if(medico == null){
                medico = _RepoJoven.ConsultarNutricionista(joven.Id);
            }
            listaPatrones = _RepoJoven.GetPatronesJoven(Id);
            if(!listaPatrones.Any()){
                return RedirectToPage("./Index");
            }
            else{
                return Page();
            }
        }
    }
}
