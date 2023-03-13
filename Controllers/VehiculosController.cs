using Microsoft.AspNetCore.Mvc;
using VM2.AccesoDatos.Data.Repositorios;
using VM2.AccesoDatos;
using VM2.Model;
using VM2.AccesoDatos.Data.Implementaciones;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VM2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VehiculosController> _logger;

        public VehiculosController(ILogger<VehiculosController> logger, IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _contenedorTrabajo.Vehiculos.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        // GET api/<PersonasController>/0000000001 Genera todos los datos de la persona
       
        public IActionResult Get(int id)
        {
            var result = _contenedorTrabajo.Vehiculos.GetAll().Where(c => c.IdVehiculo == id);
            return Ok(result);
        }



        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] Vehiculos vehiculos)
        {
            try
            {
                _contenedorTrabajo.Vehiculos.Update(vehiculos);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Vehiculos vehiculos)
        {
            try
            {
                _contenedorTrabajo.Vehiculos.Add(vehiculos);

            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        
              
        
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
