using MediatR;
using Dominio;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aplicacion.personas
{
    public class Eliminar
    {
    
        public class Ejecuta_Eliminar : IRequest {
            public int ID {get;set;}
        }
            public class Manejador : IRequestHandler<Ejecuta_Eliminar>
            {
                private readonly personasContext _context;
                public Manejador(personasContext context){
                    _context = context;
                }

            public async Task<Unit> Handle(Ejecuta_Eliminar request, CancellationToken cancellationToken)
            {
                var personas = await _context.persona.FindAsync(request.ID);
                if(personas==null){
                    throw new Exception("no se puede eliminar esta persona");
                }
                _context.Remove(personas);
                var resultado = await _context.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar los cambios");
            }
        }
    }
        
    }