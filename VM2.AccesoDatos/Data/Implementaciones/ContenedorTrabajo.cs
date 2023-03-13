using VM2.AccesoDatos.Data.Repositorios;
//using VM2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace VM2.AccesoDatos.Data.Implementaciones
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Personas = new PersonasRepositorio(_db);
            Placas = new PlacasRepositorio(_db);
            Vehiculos = new VehiculosRepositorio(_db);




        }

        public IPersonasRepositorio Personas { get; private set; }
        public IPlacasRepositorio Placas { get; private set; }
        public IVehiculosRepositorio Vehiculos { get; private set; }
        public ITipoPersonasRepositorio TipoPersonas { get; private set; }
        
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
