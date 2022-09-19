using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HogarGestor.App.Presentacion.Pages_BDMedicos
{
    public class SugerenciaCuidadoModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        private readonly IRepositorioMedico _RepoMedico;
        [BindProperty]
        public Joven joven{get;set;}
        [BindProperty]
        public Medico medico{get;set;}
        [BindProperty]
        public Historia historia {get;set;}
        [BindProperty]
        public SugerenciaCuidado sugerencia {get;set;}
        [BindProperty]
        public List<SugerenciaCuidado> listaSugerencias {get;set;}
        public SugerenciaCuidadoModel(IRepositorioJoven _RepoJoven, IRepositorioMedico _RepoMedico){
            this._RepoJoven = _RepoJoven;
            this._RepoMedico = _RepoMedico;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                medico = _RepoJoven.ConsultarPediatra(joven.Id);
                if (medico == null){
                    medico = _RepoJoven.ConsultarNutricionista(joven.Id);
                }
                return Page();
            }
        }

        public IActionResult OnPostSave(){
            historia = _RepoJoven.GetHistoriaJoven(joven.Id);
            if(historia == null){
                historia = new Historia{
                    Registro = "Inicial",
                    SugerenciasCuidado = listaSugerencias
                    };
                historia.SugerenciasCuidado.Add(sugerencia);
                historia = _RepoJoven.ToAssignHistoria(joven.Id, historia);
            }
            else{
                
                listaSugerencias.Add(sugerencia);
                historia.SugerenciasCuidado = listaSugerencias;
                historia = _RepoJoven.ToAssignHistoria(joven.Id, historia);
            }
            return RedirectToPage("./Index");
        }
    }
}
