using System;

namespace UCP.App.Dominio
{
    public class Parqueadero
    {
        public int id {get;set;}
        
        public string direccion {get;set;}
        
        public int cantidadPuestos{get;set;}

        public string horario {get;set;}

        public string picoPlaca{get;set;}

        public System.Collections.Generic.List<Persona> personas{get;set;}

        public System.Collections.Generic.List<Puesto> puestos{get;set;}

        public System.Collections.Generic.List<Transaccion> transacciones{get;set;}


    }
}