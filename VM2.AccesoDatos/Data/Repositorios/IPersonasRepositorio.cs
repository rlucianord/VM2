using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Text;
using VM2.Model;

namespace VM2.AccesoDatos.Data.Repositorios
{
    public interface IPersonasRepositorio : IRepositorio<Personas>
    {
        public IEnumerable<SelectListItem> GetListaPersonas();
        public IEnumerable<TipoPersonas> GetTipoPersona();

        public IEnumerable<VehiculosPersonasDTO> GetDatosPersonas();

        void Update(VehiculosPersonasDTO personas);
       // public Personas ConvertfromDTO(VehiculosPersonasDTO personas);

        void Delete(VehiculosPersonasDTO personas);
    }
}
