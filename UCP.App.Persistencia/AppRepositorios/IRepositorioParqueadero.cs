using System.Collections.Generic;
using UCP.App.Dominio;


namespace UCP.App.Persistencia
{
    public interface IRepositorioParqueadero
    {
        //CRUD 
        //AddParqueadero
        Parqueadero AddParqueadero(Parqueadero parqueadero);
        //GetParqueadero
        Parqueadero GetParqueadero(int parqueaderoid);
        //UpdateParqueadero
        Parqueadero UpdateParqueadero(Parqueadero parqueadero);
        //DeleteParqueadero
        bool DeleteParqueadero(int parqueaderoid);
        //GetAllParqueaderoes
        IEnumerable<Parqueadero> GetAllParqueaderos();
    }
    
}