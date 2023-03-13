using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM2.Model;

namespace VM2.AccesoDatos.Data.Repositorios
{
    public interface ITipoPersonasRepositorio : IRepositorio<TipoPersonas>
    {

        public IEnumerable<SelectListItem> GetListaPersonas();

        public IEnumerable<VehiculosPersonasDTO> GetDatosPersonas();
        void Update(TipoPersonas tipopersonas);


        void Delete(TipoPersonas tipopersonas);
    }
}
