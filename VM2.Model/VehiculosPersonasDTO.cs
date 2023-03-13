using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM2.Model
{
    public class VehiculosPersonasDTO
    {

        public int IdPersona { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int TipoPersona { get; set; }
        public string? PlacaNumero { get; set; }
        public int TipoVehiculo { get; set; }
        public DateTime? FechaVenta { get; set; }
        public double ValorPlaca { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Anio { get; set; }

    }
}
