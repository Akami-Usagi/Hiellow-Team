using System;
using System.Collections.Generic;  
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Presentacion.Pages_BDMedicos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioMedico _RepoMedico;

        private readonly IRepositorioGenero _RepoGenero;

        [BindProperty]
        public Medico medico { get; set; }

        public IEnumerable<SelectListItem> Options { get; set; }

        public EditModel(
            IRepositorioMedico _RepoMedico,
            IRepositorioGenero _RepoGenero
        )
        {
            this._RepoMedico = _RepoMedico;
            this._RepoGenero = _RepoGenero;
        }

        public IActionResult OnGet(int Id)
        {
            Options =
                _RepoGenero
                    .GetAllGeneros()
                    .Select(a =>
                        new SelectListItem()
                        { Text = a.Nombre, Value = a.Id.ToString() });

            medico = _RepoMedico.GetMedico(Id);
            if (medico == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPostEdit()
        {
            medico = _RepoMedico.UpdateMedico(medico);
            return RedirectToPage("./Index");
        }
    }
}
