using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_Jovenes{
    public class indexModel : PageModel{

        private readonly IRepositorioJovenMemoria _RepoJovenMemoria;
        public IEnumerable<Joven> Jovenes {get;set;}
        public indexModel(IRepositorioJovenMemoria _RepoJovenMemoria){
            this._RepoJovenMemoria = _RepoJovenMemoria;
        }

        public void OnGet(){
            Jovenes = _RepoJovenMemoria.GetAll();
        }
    }
}
