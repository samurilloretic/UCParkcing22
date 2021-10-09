using System.Collections.Generic;
using UCP.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
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
        Profesor IRepositorioProfesor.GetProfesor(int profesorid)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id==profesorid);
            return profesorEncontrado;
        }
        //ActualizarProfesor
        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            Console.WriteLine(profesor.nombre);
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p=>p.id==profesor.id);
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

        bool IRepositorioProfesor.DeleteProfesor(int profesorid)
        {
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p=>p.id==profesorid);
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

        Profesor IRepositorioProfesor.GetProfesorVehiculo(int idProfesor)
        {
            return _appContext.Profesores.Include(p=>p.vehiculo_1).Include(p=>p.vehiculo_2).SingleOrDefault(p=>p.id==idProfesor);
        }

    }
}