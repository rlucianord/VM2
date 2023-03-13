using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Text;
using VM2.Model;

namespace VM2.AccesoDatos.Data.Repositorios
{


    public interface IVehiculosRepositorio : IRepositorio<Vehiculos>
    {
        public IEnumerable<Placas> GetListaTipolacas();

        public IEnumerable<VehiculosPersonasDTO> GetDatosPersonas();
        void Update(Vehiculos vehiculos);


        void Delete(Vehiculos vehiculos);
    }
   
}
