using System;

namespace UCP.App.Dominio
{
    public class Vehiculo
    {
        public int id {get;set;}
        public string marca{get;set;}
        public string modelo{get;set;}
        public string placa{get;set;}
        public TipoVehiculo tipoVehiculo{get;set;}
    }    
}