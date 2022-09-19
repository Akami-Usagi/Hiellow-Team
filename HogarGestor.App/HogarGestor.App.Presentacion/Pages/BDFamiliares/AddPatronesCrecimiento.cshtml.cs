using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Presentacion.Pages_BDFamiliares
{
    public class AddPatronesCrecimientoModel : PageModel
    {
        private readonly IRepositorioJoven _RepoJoven;

        [BindProperty]
        public PatronesCrecimiento PatronesCrecimiento{get; set;}

        [BindProperty]
        public Joven Joven{get; set;}

        public AddPatronesCrecimientoModel(IRepositorioJoven _RepoJoven){
            this._RepoJoven = _RepoJoven;
        }
        public IActionResult OnGet(int id)
        {
            Joven = _RepoJoven.GetJoven(id);
            if (Joven == null)
            {
                return RedirectToPage("./NotFound");
            }else{
                return Page();
            }
            
        }

        public ActionResult OnPostSave(){
            if (Joven.Id > 0)
            {
                var joven = _RepoJoven.GetJoven(Joven.Id);
                if (joven!=null){
                    if (joven.PatronesCrecimientoJoven!=null)
                    {
                        joven.PatronesCrecimientoJoven.Add(PatronesCrecimiento);
                    }else{
                        joven.PatronesCrecimientoJoven = new List<PatronesCrecimiento>{
                            new PatronesCrecimiento{
                                Medicion = PatronesCrecimiento.Medicion,
                                Valor = PatronesCrecimiento.Valor,
                            }
                        };
                    }

                    _RepoJoven.UpdateJoven(joven);
                }

                return RedirectToPage("Index");
            }else{
                return Page();
            }
        }
    }
}
