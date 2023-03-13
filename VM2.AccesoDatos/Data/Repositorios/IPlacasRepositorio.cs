using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Text;
using VM2.Model;

namespace VM2.AccesoDatos.Data.Repositorios
{
    public interface IPlacasRepositorio : IRepositorio<Placas>
    {
        public IEnumerable<SelectListItem> GetListaPlacas();

        public IEnumerable<VehiculosPersonasDTO> GetDatosPersonas();
        void Update(Placas placas);
        void Delete(Placas placas);
    }
}
