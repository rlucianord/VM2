using System;
using System.Collections.Generic;
using System.Text;

namespace VM2.AccesoDatos.Data.Repositorios
{
    public interface IContenedorTrabajo : IDisposable
    {
        IPersonasRepositorio Personas { get; }
        IPlacasRepositorio Placas { get; }
        IVehiculosRepositorio Vehiculos { get; }



        void Save();
    }
}
