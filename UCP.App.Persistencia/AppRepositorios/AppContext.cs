using Microsoft.EntityFrameworkCore;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;} //repertirse por cada entidad

        public DbSet<Estudiante> Estudiantes{get;set;} //repertirse por cada entidad

        public DbSet<Profesor> Profesores{get;set;} //repertirse por cada entidad

        public DbSet<Visitante> Visitantes{get;set;} //repertirse por cada entidad

        public DbSet<Parqueadero> Parquaderos{get;set;} //repertirse por cada entidad
        
        public DbSet<Puesto> Puestos{get;set;} //repertirse por cada entidad
        
        public DbSet<Transaccion> Transacciones{get;set;} //repertirse por cada entidad

        public DbSet<Vehiculo> Vehiculos{get;set;} //repertirse por cada entidad

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog= UCParking22");
            }

        }

    }
}