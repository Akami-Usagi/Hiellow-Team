using System.Collections.Generic;
using HogarGestor.App.Persistencia;
using HogarGestor.App.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HogarGestor.App.FrontEnd.Pages{

    public class ListModel : PageModel{

        // private string[] Saludos = {"Buenos Dias", "Buenas Tardes", "Buenas Noches", "Hasta Luego"};
        // public List<string> ListaSaludos {get; set;}
        private readonly IRepositorioSaludos repositorioSaludos;
        public IEnumerable<Saludo> Saludos {get;set;}

        public ListModel(IRepositorioSaludos repositorioSaludos){
            this.repositorioSaludos = repositorioSaludos;
        }

        public void OnGet(){
            // ListaSaludos = new List<string>();
            // ListaSaludos.AddRange(Saludos);
            Saludos = repositorioSaludos.GetAll();
        }
    }
}
