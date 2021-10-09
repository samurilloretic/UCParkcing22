using System.Collections.Generic;
using UCP.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace UCP.App.Persistencia
{
    public class RepositorioParqueadero : IRepositorioParqueadero
    {
        private readonly AppContext _appContext;

        public RepositorioParqueadero(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD 
        //AgregarParqueadero
        Parqueadero IRepositorioParqueadero.AddParqueadero(Parqueadero parqueadero)
        {
            var ParqueaderoAdicionado = _appContext.Parqueaderos.Add(parqueadero);
            _appContext.SaveChanges();
            return ParqueaderoAdicionado.Entity;
        }
        //BuscarParqueadero
        Parqueadero IRepositorioParqueadero.GetParqueadero(int parqueaderoid)
        {
            var ParqueaderoEncontrado = _appContext.Parqueaderos.FirstOrDefault(p => p.id==parqueaderoid);
            return ParqueaderoEncontrado;
        }
        //ActualizarParqueadero
        Parqueadero IRepositorioParqueadero.UpdateParqueadero(Parqueadero parqueadero)
        {
            var ParqueaderoEncontrado = _appContext.Parqueaderos.FirstOrDefault(p=>p.id==parqueadero.id);
            if (ParqueaderoEncontrado!=null)
            {
                ParqueaderoEncontrado.direccion = parqueadero.direccion;
                ParqueaderoEncontrado.cantidadPuestos = parqueadero.cantidadPuestos;
                ParqueaderoEncontrado.horario = parqueadero.horario;
                ParqueaderoEncontrado.picoPlaca = parqueadero.picoPlaca;
                ParqueaderoEncontrado.puestos = parqueadero.puestos;
                ParqueaderoEncontrado.transacciones = parqueadero.transacciones;
                ParqueaderoEncontrado.personas = parqueadero.personas;

                
            _appContext.SaveChanges();          
            }
            return ParqueaderoEncontrado;
        }
        //BorrarParqueadero

        bool IRepositorioParqueadero.DeleteParqueadero(int parqueaderoid)
        {
            var ParqueaderoEncontrado = _appContext.Parqueaderos.FirstOrDefault(p=>p.id==parqueaderoid);
            if (ParqueaderoEncontrado==null)
                return false;
            _appContext.Parqueaderos.Remove(ParqueaderoEncontrado);
            _appContext.SaveChanges();
            return true;
        }

        //BuscarParqueaderoes
        IEnumerable<Parqueadero> IRepositorioParqueadero.GetAllParqueaderos()
        {
            return _appContext.Parqueaderos;
        }
    }
}