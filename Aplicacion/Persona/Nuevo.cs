using MediatR;
using Dominio;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aplicacion.personas
{
    public class Nuevo{
        public class Ejecuta : IRequest{
            public int Id { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Identificacion { get; set; }
            public DateTime Fecha_de_Nacimiento { get; set; }
            public int tipo_id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
                private readonly personasContext _context;
                public Manejador(personasContext context){
                    _context = context;
                }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var personas = new persona {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Fecha_de_Nacimiento = request.Fecha_de_Nacimiento,
                    Identificacion = request.Identificacion,
                    tipo_id = request.tipo_id
                    
                };
                    _context.persona.Add(personas);
                   var valor = await _context.SaveChangesAsync();
                   if(valor>0){
                    return Unit.Value;
                   }
                   throw new Exception("No se pudo insertar la persona");
            }
        }
    }
}
