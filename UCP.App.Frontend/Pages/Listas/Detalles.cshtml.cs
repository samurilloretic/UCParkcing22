using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Persistencia;
using UCP.App.Dominio;
using System.Diagnostics;

namespace UCP.App.Frontend.Pages
{
    public class DetallesModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());

        public Profesor profesor{get;set;}

        public IActionResult OnGet(int profesorIdentificacion)
        {
            profesor = _repoProfesor.GetProfesor(profesorIdentificacion);
            if(profesor == null)
            {
                return RedirectToPage("./Profesores");
            }
            return Page();
        }
    }
}
