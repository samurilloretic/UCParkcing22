using System.Collections.Generic;
using UCP.App.Dominio;


namespace UCP.App.Persistencia
{
    public interface IRepositorioProfesor
    {
        //CRUD 
        //AddProfesor
        Profesor AddProfesor(Profesor profesor);
        //GetProfesor
        Profesor GetProfesor(int profesorid);
        //UpdateProfesor
        Profesor UpdateProfesor(Profesor profesor);
        //DeleteProfesor
        bool DeleteProfesor(int profesorid);
        //GetAllProfesores
        IEnumerable<Profesor> GetAllProfesores();
    }
    
}