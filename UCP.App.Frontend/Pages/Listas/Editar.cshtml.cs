using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Persistencia;
using UCP.App.Dominio;
using System.CodeDom;
using System.Diagnostics;

namespace UCP.App.Frontend.Pages
{
    public class EditarModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor= new RepositorioProfesor(new Persistencia.AppContext());
        [BindProperty]
        public Profesor profesor{get;set;}
        public IActionResult OnGet(int profesorIdentificacion)
        {
            //Console.WriteLine(profesorId);
            profesor = _repoProfesor.GetProfesor(profesorIdentificacion);
            if (profesor==null)
            {
                return RedirectToPage("./Profesores");            
            }else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            //Console.WriteLine(profesor.nombre);
            _repoProfesor.UpdateProfesor(profesor);
            return RedirectToPage("./Profesores");
        }
    }
}
