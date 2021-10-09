using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
using System.Globalization;

namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        private static IRepositorioVehiculo _repoVehiculo = new RepositorioVehiculo(new Persistencia.AppContext());
        private static IRepositorioParqueadero _repoParqueadero = new RepositorioParqueadero(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CrearProfesor();            
            /*Profesor profesorConsultado = ConsultarProfesorVehiculo(8);
            Console.WriteLine(profesorConsultado.nombre);
            Console.WriteLine(profesorConsultado.apellidos);
            Console.WriteLine(profesorConsultado.vehiculo_2);//error
            Console.WriteLine(profesorConsultado.vehiculo_2.marca);//error
*/

            //EditarProfesor(5);
            //EliminarProfesor(5);
            //ConsultarProfesores();
            /*Vehiculo vehiculonuevo1 = new Vehiculo{
                marca = "Audi",
                modelo = "A4",
                placa = "ARZ142",
                tipoVehiculo = TipoVehiculo.automovil
            };
            Vehiculo vehiculonuevo2 = new Vehiculo{
                marca = "Fiat",
                modelo = "Palio",
                placa = "ART321",
                tipoVehiculo = TipoVehiculo.automovil
            };
            AgregarVehiculoProfesor(vehiculonuevo1,vehiculonuevo2,8);
            */
            /*Vehiculo vehiculoEncontrado = _repoVehiculo.GetVehiculo(1);
            AgregarVehiculoProfesor(vehiculoEncontrado,null,2);*/
            //Vehiculo nuevoVehiculo = _repoVehiculo.GetVehiculo(1);
            //AgregarParqueadero();
            Persona personaEncontrada = ConsultarProfesor(7);
            EditarParqueadero(3,personaEncontrada);
        }
        //CRUD
        //CrearProfesor
        private static void CrearProfesor()
        {

            Vehiculo vehiculo_eje_1 = new Vehiculo{
                marca = "Mazda",
                modelo = "Cx-30",
                placa = "ABA911",
                tipoVehiculo = TipoVehiculo.automovil
            };

            var profesor = new Profesor{
                nombre = "Camilo",
                apellidos = "Suarez",
                identificacion = 10101010,
                correoElectronico = "camilosuarez.tic@ucaldas.edu.co",
                telefono = "30101010",
                vehiculo_1 = vehiculo_eje_1,
                vehiculo_2 = null,
                facultad = "Ingeniería",
                cubiculo = "1"
            };
            Profesor profesorGuardado=_repoProfesor.AddProfesor(profesor);
            if (profesorGuardado!=null)
                Console.WriteLine("Se registró un profesor con éxito");
                else
                {
                    Console.WriteLine("Hubo un error de conexión con la base de datos");
                }
        }
        //ConsultarProfesor
        private static Profesor ConsultarProfesor(int idProfesor)
        {
            Profesor profesorEncontrado = _repoProfesor.GetProfesor(idProfesor);
            if (profesorEncontrado!=null)
            {
                Console.WriteLine(profesorEncontrado.nombre);
                return profesorEncontrado;
            }
            else
            {
                Console.WriteLine("Profesor no encontrado");
                return null;
            }            
        }
        //EditarProfesor
        private static void EditarProfesor(int idProfesor)
        {
            var profesor = new Profesor{
                id = idProfesor,
                nombre = "Santiago",
                apellidos = "Rendon",
                identificacion = 10200020,
                correoElectronico = "santiagorendon.tic@ucaldas.edu.co",
                telefono = "30200001",
                vehiculo_1 = null,
                vehiculo_2 = null,
                facultad = "Ingeniería",
                cubiculo = "8"
            };
            var profesorActualizado = _repoProfesor.UpdateProfesor(profesor);
            if (profesorActualizado!=null)
            {
                Console.WriteLine("Se actualizó el profesor con identificación: " + profesorActualizado.identificacion);
            }else
            {
                Console.WriteLine("No se encontró el profesor que se iba a actualizar");
            }

        }
        //EliminarProfesor
        private static void EliminarProfesor(int id)
        {
            if(_repoProfesor.DeleteProfesor(id))
                Console.WriteLine("Profesor Eliminado");
            else
            {
                Console.WriteLine("No se pudo eliminar el profesor con esta identificación,\nverifique que es la identificación correcta.");
            }
        }
        //ConsultarProfesores
        private static void ConsultarProfesores()
        {
            IEnumerable<Profesor> profesores = _repoProfesor.GetAllProfesores();

            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor.nombre + "  " + profesor.apellidos+ "  " + profesor.facultad);
            }
        }

        private static void AgregarVehiculoProfesor(Vehiculo vehiculo1,Vehiculo vehiculo2,int idProfesor)
        {
            Profesor profesorEncontrado = _repoProfesor.GetProfesor(idProfesor);
            profesorEncontrado.vehiculo_1 = vehiculo1;
            profesorEncontrado.vehiculo_2 = vehiculo2;
            _repoProfesor.UpdateProfesor(profesorEncontrado);
        }

        private static Profesor ConsultarProfesorVehiculo(int idProfesor)
        {
            return _repoProfesor.GetProfesorVehiculo(idProfesor);
        }

        private static Parqueadero AgregarParqueadero()
        {            
            var parqueaderoCreado = new Parqueadero 
            {
                direccion="Carrera 10 #23 - 18",
                horario = "Lunes a Sábado 8 a 20",
                picoPlaca = "3",
                cantidadPuestos = 50,
                puestos = new List<Puesto> {
                    new Puesto{
                        tipoVehiculo =TipoVehiculo.camioneta,
                        estado = Estado.ocupado,
                        numero = 1,
                        vehiculo = new Vehiculo {
                            placa = "POR342",
                            marca = "Mazda",
                            modelo ="CX-5",
                            tipoVehiculo = TipoVehiculo.camioneta
                        }
                    },
                    new Puesto{
                        tipoVehiculo =TipoVehiculo.automovil,
                        estado = Estado.ocupado,
                        numero = 2,
                        vehiculo = new Vehiculo {
                            placa = "ATM987",
                            marca = "Renault",
                            modelo ="Sandero",
                            tipoVehiculo = TipoVehiculo.automovil
                        }
                    },
                    new Puesto{
                        tipoVehiculo =TipoVehiculo.automovil,
                        estado = Estado.libre,
                        numero = 3,
                        vehiculo = null
                    }
                },
                transacciones = null,
                personas = null
            };
            return _repoParqueadero.AddParqueadero(parqueaderoCreado);
        }

        private static Parqueadero EditarParqueadero(int idParqueadero,Persona persona)
        {
            var parqueaderoEncontrado = _repoParqueadero.GetParqueadero(idParqueadero);
            if (parqueaderoEncontrado.personas == null){
                parqueaderoEncontrado.personas = new List<Persona>();
                parqueaderoEncontrado.personas.Add(persona);
                Console.WriteLine("Se va a crear la lista");
            }else
            {
                parqueaderoEncontrado.personas.Add(persona);
                Console.WriteLine("La lista ya existe");
            }
            return _repoParqueadero.UpdateParqueadero(parqueaderoEncontrado);
        }
    }
}
