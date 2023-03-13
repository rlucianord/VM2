using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VM2.AccesoDatos.Data.Repositorios;
using VM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM2.AccesoDatos.Data.Implementaciones
{
    public class PersonasRepositorio : Repositorio<Personas>, IPersonasRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PersonasRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaPersonas()
        {
            return _db.Personas.Select(i => new SelectListItem()
            {
                Value = i.IdPersona.ToString()
            });

        }

       
        public void Update(VehiculosPersonasDTO personas)
        {

            var DatosPersona = (Personas)personas;

            _db.Entry(DatosPersona).State = EntityState.Modified;
           // _db.Personas.Entry(DatosPersona).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(VehiculosPersonasDTO personas)
        {
            var DatosPersona = (Personas)personas;


            _db.Entry(DatosPersona).State = EntityState.Deleted;
            _db.SaveChanges();
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

        IEnumerable<TipoPersonas> IPersonasRepositorio.GetTipoPersona()
        {
            return _db.TipoPersonas.ToList();

        }

        
    }
}
