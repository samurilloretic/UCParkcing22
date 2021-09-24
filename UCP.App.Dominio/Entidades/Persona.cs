using System;

namespace UCP.App.Dominio
{
   public class Persona
   {
       public int id {get;set;}

       public string nombre{get;set;}

       public string apellidos{get;set;}

       public int identificacion{get;set;}

       public string correoElectronico{get;set;}

       public string telefono{get;set;}

       public Vehiculo vehiculo_1{get;set;}

       public Vehiculo vehiculo_2{get;set;}
   } 
}