using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistencia.DapperConexion.Persona;

namespace Aplicacion.Persona_Procedure
{
    public class Editar
    {
          public class Ejecuta : IRequest {
            public int id {get;set;}
             public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Identificacion { get; set; }
            public DateTime Fecha_de_Nacimiento { get; set; }
            public int tipo_id { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>{
            public EjecutaValida(){
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Identificacion).NotEmpty();
            }
            
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
           private readonly IPersona _PersonaRepository;
            public Manejador(IPersona PersonaRepository){
                _PersonaRepository = PersonaRepository;
            }
        
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultado = await _PersonaRepository.Actualizar(request.id,request.Nombres, request.Apellidos, 
                request.Identificacion,request.Fecha_de_Nacimiento,request.tipo_id);

                if(resultado > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se pudo editar persona");
            }
        }

    }
}