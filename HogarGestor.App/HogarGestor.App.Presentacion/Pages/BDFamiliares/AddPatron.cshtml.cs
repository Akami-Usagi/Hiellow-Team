using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Presentacion.Pages_BDFamiliares
{
    public class AddPatronModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;
        [BindProperty]
        public PatronesCrecimiento patrones {get;set;}
        [BindProperty]
        public Historia historia {get;set;}
        [BindProperty]
        public Joven joven {get;set;}
        public AddPatronModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int Id)
        {
            joven = _RepoJoven.GetJoven(Id);
            if(joven == null){
                return RedirectToPage("./NotFound");
            }
            else{
                
                return Page();
            }
        }

        public IActionResult OnPostSave(){
            if(joven.Id > 0){
                var jovenFound = _RepoJoven.GetJoven(joven.Id);
                if(jovenFound != null){
                    if(jovenFound.HistoriaJoven != null){
                        historia = new Historia{Registro = "Inicial"};
                        jovenFound.HistoriaJoven = historia;
                        if(jovenFound.HistoriaJoven.PatronCrecimiento != null){
                            jovenFound.HistoriaJoven.PatronCrecimiento.Add(patrones);
                        }
                        else{
                            jovenFound.HistoriaJoven.PatronCrecimiento = new List<PatronesCrecimiento>{
                                    new PatronesCrecimiento{
                                        Medicion = patrones.Medicion,
                                        Valor = patrones.Valor
                                    }
                                };
                            
                        }
                        _RepoJoven.UpdateJoven(jovenFound);
                    }

                }
                return RedirectToPage("./Index");
            }
            else{return Page();
            }
        }


    }
}
