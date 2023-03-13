using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VM2.AccesoDatos.Data.Repositorios;
using VM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace VM2.AccesoDatos.Data.Implementaciones
{
    public class VehiculosRepositorio : Repositorio<Vehiculos>, IVehiculosRepositorio
    {
        private readonly ApplicationDbContext _db;

        public VehiculosRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    
       
        public IEnumerable<VehiculosPersonasDTO> GetDatosPersonas()
        {


            var DatosPersona = (from v in _db.Vehiculos
                                join p in _db.Personas
                                on v.IdPersona equals p.IdPersona
                                join pl in _db.Placas
                                on v.PlacaNumero equals pl.PlacaNumero
                                select new VehiculosPersonasDTO
                                {
                                    IdPersona = p.IdPersona,
                                    Nombres = p.Nombres,
                                    Apellidos = p.Apellidos,
                                    Cedula = p.Cedula,
                                    FechaNacimiento = p.FechaNacimiento,
                                    TipoPersona = p.TipoPersona,
                                    PlacaNumero = v.PlacaNumero,
                                    TipoVehiculo = pl.TipoVehiculo,
                                    FechaVenta = pl.FechaVenta,
                                    ValorPlaca = pl.ValorPlaca,
                                    Marca = v.Marca,
                                    Modelo = v.Modelo,
                                    Anio = v.Anio



                                }).ToList();

            return DatosPersona;

        }

        public IEnumerable<Placas> GetListaTipolacas()
        {
           var Placas= _db.Placas.Where(a => !a.Vehiculos.Any(m => m.PlacaNumero.Equals(a.PlacaNumero) && m.TipoVehiculo==a.TipoVehiculo)).AsEnumerable();
            return Placas;





        }

        public void Update(Vehiculos vehiculos)
        {
            
            _db.Entry(vehiculos).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Vehiculos vehiculos)
        {
            _db.Entry(vehiculos).State = EntityState.Deleted;
            _db.SaveChanges();
        }
    }
}
