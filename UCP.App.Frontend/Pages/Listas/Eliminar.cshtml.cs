using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Persistencia;
using UCP.App.Dominio;
namespace UCP.App.Frontend.Pages
{
    public class EliminarModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor= new RepositorioProfesor(new Persistencia.AppContext());
        [BindProperty]
        public Profesor profesor{get;set;}

        public IActionResult OnGet(int profesorId)
        {
            profesor = _repoProfesor.GetProfesor(profesorId);
            return Page();
        }
        public IActionResult OnPost()
        {
            _repoProfesor.DeleteProfesor(profesor.id);
            return RedirectToPage("./Profesores");
        }
    }
}
