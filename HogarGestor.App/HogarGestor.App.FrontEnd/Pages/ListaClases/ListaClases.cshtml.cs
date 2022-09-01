using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HogarGestor.App.FrontEnd.Pages
{
    public class ListaClasesModel : PageModel
    {

        private string[] Clases = {"Persona", "Medico", "Familiar"};

        public List<string> ListaClases {get;set;}

        public void OnGet()
        {
            ListaClases = new List<string>();
            ListaClases.AddRange(Clases);
        }
    }
}
