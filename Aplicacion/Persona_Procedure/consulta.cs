using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Persona;

namespace Aplicacion.Persona_Procedure
{
    public class consulta
    {
        public class Lista : IRequest<List<PersonaModel>>{}
        public class Manejador : IRequestHandler<Lista, List<PersonaModel>>{

            private readonly IPersona _personaRepository;

            public Manejador(IPersona personaRepository){
                _personaRepository = personaRepository;
            }                       

            public async Task<List<PersonaModel>> Handle(Lista request, CancellationToken cancellationToken)
            {
               
               var resultado = await _personaRepository.ObtenerLista();
               return resultado.ToList();
            }
        }
    }
}