using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Persistencia.DapperConexion.Persona;
using Aplicacion.Persona_Procedure;

namespace WebAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class Personas_ProcedureController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PersonaModel>>> ObtenerPersonas(){
            return await Mediator.Send(new consulta.Lista());
        }

    }
}