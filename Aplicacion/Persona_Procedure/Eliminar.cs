using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Persona;

namespace Aplicacion.Persona_Procedure
{
    public class Eliminar
    {
         public class Ejecuta : IRequest{
            public int Id {get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IPersona _PersonaRepository;
            public Manejador(IPersona PersonaRepository){
                _PersonaRepository = PersonaRepository;
            }
            
        
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                 var resultados = await _PersonaRepository.Elimina(request.Id);
                if(resultados>0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar la persona");
            }
        }
    }
}