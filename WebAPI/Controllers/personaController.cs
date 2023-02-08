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
        private readonly IMediator _mediator;
        public personaController(IMediator mediator){
            _mediator=mediator;
        }
        [HttpGet]
        
        public async Task<ActionResult<List<persona>>> Get(){
            return  await _mediator.Send(new Consulta.Listapersonas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<persona>> Detalle(int id){
            return  await _mediator.Send( new Consultaid.PersonaUnica{ID = id});
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data){
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id,Editar.Ejecuta_Edicion data){
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id){
            return await _mediator.Send(new Eliminar.Ejecuta_Eliminar{ID = id});
        }
    }
    
}