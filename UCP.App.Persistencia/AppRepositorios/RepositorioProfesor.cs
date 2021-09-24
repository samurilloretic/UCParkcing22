using System.Collections.Generic;
using UCP.App.Dominio;
using System.Linq;

namespace UCP.App.Persistencia
{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private readonly AppContext _appContext;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD 
        //AgregarProfesor
        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            var profesorAdicionado = _appContext.Profesores.Add(profesor);
            _appContext.SaveChanges();
            return profesorAdicionado.Entity;
        }
        //BuscarProfesor
        Profesor IRepositorioProfesor.GetProfesor(int identificacion)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.identificacion==identificacion);
            return profesorEncontrado;
        }
        //ActualizarProfesor
        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p=>p.identificacion==profesor.identificacion);
            if (profesorEncontrado!=null)
            {
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellidos = profesor.apellidos;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.telefono = profesor.telefono;
                profesorEncontrado.correoElectronico = profesor.correoElectronico;
                profesorEncontrado.vehiculo_1 = profesor.vehiculo_1;
                profesorEncontrado.vehiculo_2 = profesor.vehiculo_2;
                profesorEncontrado.facultad = profesor.facultad;
                profesorEncontrado.cubiculo = profesor.cubiculo;
                
            _appContext.SaveChanges();          
            }
            return profesorEncontrado;
        }
        //BorrarProfesor

        bool IRepositorioProfesor.DeleteProfesor(int identificacion)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p=>p.identificacion==identificacion);
            if (profesorEncontrado==null)
                return false;
            _appContext.Profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
            return true;
        }

        //BuscarProfesores
        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            return _appContext.Profesores;
        }

    }
}