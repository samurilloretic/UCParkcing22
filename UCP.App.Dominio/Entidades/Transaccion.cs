using System;

namespace UCP.App.Dominio
{
    public class Transaccion
    {
        public int id {get;set;}
        public DateTime horaIngreso{get;set;}
        public DateTime horaSalida{get;set;}
        public float tarifaHora{get;set;}
    }
}