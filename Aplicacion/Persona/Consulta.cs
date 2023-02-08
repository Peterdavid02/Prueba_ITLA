using System.Collections.Generic;
using MediatR;
using Dominio;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Aplicacion.personas
{
    public class Consulta
    {
    
        public class Listapersonas : IRequest<List<persona>> {}
            public class Manejador : IRequestHandler<Listapersonas , List<persona>>
            {
                private readonly personasContext _context;
                public Manejador(personasContext context){
                    _context = context;
                }

            public async Task<List<persona>> Handle(Listapersonas request, CancellationToken cancellationToken)
            {
        
            var personas = await _context.persona.ToListAsync();
            return personas;
                
            
            }
        }
    }
        
    }