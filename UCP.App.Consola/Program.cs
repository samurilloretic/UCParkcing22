using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CrearProfesor();
            //ConsultarProfesor(10000011);
            //EditarProfesor();
            //EliminarProfesor(10000002);
            ConsultarProfesores();
            /*Estudiante estudiante_1 = new Estudiante{
                nombre = "Santiago",
                apellidos = "Murillo",
                identificacion = 10000000,
                correoElectronico = "santiagomurillo.tic@ucaldas.edu.co",
                telefono = "30000000",
                vehiculo_1 = vehiculo_eje_1,
                vehiculo_2 = null,
                programa = "Ingeniería de Sistemas"
            } ;

            Console.WriteLine(estudiante_1.nombre + "  " +estudiante_1.apellidos+"\n"+estudiante_1.telefono+"\n"+estudiante_1.vehiculo_1.placa);
            */
        }
        //CRUD
        //CrearProfesor
        private static void CrearProfesor()
        {

            Vehiculo vehiculo_eje_1 = new Vehiculo{
                marca = "Renault",
                modelo = "2012",
                placa = "AAA111",
                tipoVehiculo = TipoVehiculo.automovil
            };

            var profesor = new Profesor{
                nombre = "Santiago",
                apellidos = "Murillo",
                identificacion = 10000000,
                correoElectronico = "santiagomurillo.tic@ucaldas.edu.co",
                telefono = "30000000",
                vehiculo_1 = null,
                vehiculo_2 = null,
                facultad = "Ingeniería",
                cubiculo = "4"
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
        private static void ConsultarProfesor(int identificacion)
        {
            Profesor profesorEncontrado = _repoProfesor.GetProfesor(identificacion);
            if (profesorEncontrado!=null)
                Console.WriteLine(profesorEncontrado.nombre);
            else
            {
                Console.WriteLine("Profesor no encontrado");
            }
        }
        //EditarProfesor
        private static void EditarProfesor()
        {
            var profesor = new Profesor{
                nombre = "Felipe",
                apellidos = "Muñoz",
                identificacion = 10000020,
                correoElectronico = "felipemuñoz.tic@ucaldas.edu.co",
                telefono = "30000001",
                vehiculo_1 = null,
                vehiculo_2 = null,
                facultad = "Derecho",
                cubiculo = "4"
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
        private static void EliminarProfesor(int identificacion)
        {
            if(_repoProfesor.DeleteProfesor(identificacion))
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

    }
}
