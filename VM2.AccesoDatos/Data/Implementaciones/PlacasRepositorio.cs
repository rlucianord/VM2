using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VM2.AccesoDatos.Data.Repositorios;
using VM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Localization;
using System.Reflection.Emit;

namespace VM2.AccesoDatos.Data.Implementaciones
{
    public class PlacasRepositorio : Repositorio<Placas>, IPlacasRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PlacasRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaPlacas()
        {
            return _db.Placas.Select(i => new SelectListItem()
            {
                Value = i.PlacaNumero.ToString()
            });

        }


        public IEnumerable<VehiculosPersonasDTO> GetDatosPersonas()
        {
            throw new NotImplementedException();
        }

        public new void Add(Placas placas)
        {
            string Letra = _db.TipoVehiculos.FirstOrDefault(c => c.IdTipo == placas.TipoVehiculo).Tipo;
            Letra ??= "N";
            placas.PlacaNumero = string.Concat(Letra, GeneratePlacaNumber(placas.TipoVehiculo));

            _db.Entry(placas).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Update(Placas placas)
        {
            _db.Entry(placas).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(Placas placas)
        {
            _db.Entry(placas).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        public string GeneratePlacaNumber(int TipoVehiculo)
        {
            int initialNumber = 100000;
            int lastNumber = 0;
            var lastItem = _db.Placas.Where(c => c.TiposVehiculo.Equals(TipoVehiculo)).OrderByDescending(f => f.IdRegistro).FirstOrDefault().IdRegistro;

            if (lastItem > 0)
                lastNumber = lastItem;


            //  lastNumber=lastNumber > 0 ? ++lastNumber : initialNumber;
            Random r = new Random();
            var x = r.Next(lastNumber, initialNumber);

            return x.ToString("000000");
        }
    }
}
