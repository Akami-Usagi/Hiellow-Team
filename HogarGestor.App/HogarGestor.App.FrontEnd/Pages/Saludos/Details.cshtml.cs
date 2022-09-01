using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.FrontEnd.Pages
{
    public class DetailsModel : PageModel{

        private readonly IRepositorioSaludos repositorioSaludos;
        public Saludo Saludo {get;set;}
        public DetailsModel(IRepositorioSaludos repositorioSaludos){
            this.repositorioSaludos = repositorioSaludos;
        }
        public IActionResult OnGet(int saludoId){
            Saludo = repositorioSaludos.GetSaludoPorId(saludoId);
            if (Saludo == null){
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
        }
    }
}
