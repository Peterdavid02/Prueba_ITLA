using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Persona;

namespace Aplicacion.Persona_Procedure
{
    public class consultaid
    {
            public class Ejecuta_obtener : IRequest<PersonaModel> {
            public int Id  {get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta_obtener, PersonaModel>
        {
            private readonly IPersona _personaRepository;
            public Manejador(IPersona personaRepository){
                _personaRepository = personaRepository;
            }

            async Task<PersonaModel> IRequestHandler<Ejecuta_obtener, PersonaModel>.Handle(Ejecuta_obtener request, CancellationToken cancellationToken)
            {
                 var instructor = await _personaRepository.ObtenerPorId(request.Id);
                if(instructor==null){
                    throw new Exception("No se pudo encontrar la persona");
                }

                return instructor;
            }
        }
    }
}