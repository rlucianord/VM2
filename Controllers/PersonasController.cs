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
    public class PersonasController : ControllerBase
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonasController> _logger;

        public PersonasController(ILogger<PersonasController> logger, IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _contenedorTrabajo.Personas.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        // GET api/<PersonasController>/0000000001 Genera todos los datos de la persona
       
        public IActionResult Get(string id)
        {
            var result = _contenedorTrabajo.Personas.GetDatosPersonas().Where(c => c.Cedula == id);
            return Ok(result);
        }



        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] VehiculosPersonasDTO vehiculosPersonasDTO)
        {
            try
            {
                var Personaverficion = _contenedorTrabajo.Personas.GetDatosPersonas().FirstOrDefault(c => c.Cedula == vehiculosPersonasDTO.Cedula);

                if (Personaverficion != null)
                {


                    _contenedorTrabajo.Personas.Update(vehiculosPersonasDTO);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] VehiculosPersonasDTO vehiculosPersonasDTO)
        {
            try
            {
                var Personaverficion = _contenedorTrabajo.Personas.GetDatosPersonas().FirstOrDefault(c => c.Cedula == vehiculosPersonasDTO.Cedula);

                if (Personaverficion == null)
                {
                    var DatosPersona = (Personas)vehiculosPersonasDTO;
                    _contenedorTrabajo.Personas.Add(DatosPersona);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
