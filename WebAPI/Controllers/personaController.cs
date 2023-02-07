using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dominio;
using Aplicacion;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.personas;

namespace WebAPI.Controllers
{

     [Route("api/[controller]")]
     [ApiController]

      public class personaController : MiControllerBase
    {
        
        [HttpGet]
        
        public async Task<ActionResult<List<persona>>> Get(){
            return  await Mediator.Send(new Consulta.Listapersonas());
        }

    }
    
}