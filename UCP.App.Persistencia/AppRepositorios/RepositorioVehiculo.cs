using System.Collections.Generic;
using UCP.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace UCP.App.Persistencia
{
    public class RepositorioVehiculo : IRepositorioVehiculo
    {
        private readonly AppContext _appContext;

        public RepositorioVehiculo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD 
        //AgregarVehiculo
        Vehiculo IRepositorioVehiculo.AddVehiculo(Vehiculo vehiculo)
        {
            var VehiculoAdicionado = _appContext.Vehiculos.Add(vehiculo);
            _appContext.SaveChanges();
            return VehiculoAdicionado.Entity;
        }
        //BuscarVehiculo
        Vehiculo IRepositorioVehiculo.GetVehiculo(int Vehiculoid)
        {
            var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p => p.id==Vehiculoid);
            return VehiculoEncontrado;
        }
        //ActualizarVehiculo
        Vehiculo IRepositorioVehiculo.UpdateVehiculo(Vehiculo vehiculo)
        {
            var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p=>p.id==vehiculo.id);
            if (VehiculoEncontrado!=null)
            {
                VehiculoEncontrado.marca = vehiculo.marca;
                VehiculoEncontrado.modelo = vehiculo.modelo;
                VehiculoEncontrado.placa = vehiculo.placa;
                VehiculoEncontrado.tipoVehiculo = vehiculo.tipoVehiculo;

                
            _appContext.SaveChanges();          
            }
            return VehiculoEncontrado;
        }
        //BorrarVehiculo

        bool IRepositorioVehiculo.DeleteVehiculo(int Vehiculoid)
        {
            var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p=>p.id==Vehiculoid);
            if (VehiculoEncontrado==null)
                return false;
            _appContext.Vehiculos.Remove(VehiculoEncontrado);
            _appContext.SaveChanges();
            return true;
        }

        //BuscarVehiculoes
        IEnumerable<Vehiculo> IRepositorioVehiculo.GetAllVehiculos()
        {
            return _appContext.Vehiculos;
        }
    }
}