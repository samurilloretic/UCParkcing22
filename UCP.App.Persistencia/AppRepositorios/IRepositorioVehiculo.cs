using System.Collections.Generic;
using UCP.App.Dominio;


namespace UCP.App.Persistencia
{
    public interface IRepositorioVehiculo
    {
        //CRUD 
        //AddVehiculo
        Vehiculo AddVehiculo(Vehiculo Vehiculo);
        //GetVehiculo
        Vehiculo GetVehiculo(int Vehiculoid);
        //UpdateVehiculo
        Vehiculo UpdateVehiculo(Vehiculo vehiculo);
        //DeleteVehiculo
        bool DeleteVehiculo(int vehiculoid);
        //GetAllVehiculoes
        IEnumerable<Vehiculo> GetAllVehiculos();
    }
    
}