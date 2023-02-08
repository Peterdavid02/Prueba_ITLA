
using MediatR;
using Dominio;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;

namespace Aplicacion.personas
{
    public class Consultaid
    {
    
        public class PersonaUnica : IRequest<persona> {
            public int ID {get;set;}
        }
            public class Manejador : IRequestHandler<PersonaUnica , persona>
            {
                private readonly personasContext _context;
                public Manejador(personasContext context){
                    _context = context;
                }
            public async Task<persona> Handle(PersonaUnica request, CancellationToken cancellationToken)
            {
                var personas = await _context.persona.FindAsync(request.ID);
                return personas;
            }
        }
    }
        
    }