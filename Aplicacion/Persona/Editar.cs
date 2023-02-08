using MediatR;
using Dominio;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using System;

    namespace Aplicacion.personas
    {
        public class Editar{
            public class Ejecuta_Edicion : IRequest{
                public int Id { get; set; }
                public string Nombres { get; set; }
                public string Apellidos { get; set; }
                public string Identificacion { get; set; }
                public DateTime? Fecha_de_Nacimiento { get; set; }
                public int? tipo_id { get; set; }
            }
            public class Manejador : IRequestHandler<Ejecuta_Edicion>
            {
                    private readonly personasContext _context;
                    public Manejador(personasContext context){
                        _context = context;
                    }

                public async Task<Unit> Handle(Ejecuta_Edicion request, CancellationToken cancellationToken)
                {
                    var personas = await _context.persona.FindAsync(request.Id);
                    if(personas==null){
                        throw new Exception("La Persona No existe");
                    }

                    personas.Nombres = request.Nombres ?? personas.Nombres;
                    personas.Apellidos = request.Apellidos ?? personas.Apellidos;
                    personas.Identificacion = request.Identificacion ?? personas.Identificacion;
                    personas.Fecha_de_Nacimiento = request.Fecha_de_Nacimiento ?? personas.Fecha_de_Nacimiento;
                    personas.tipo_id = request.tipo_id ?? personas.tipo_id;

                    var resultado = await _context.SaveChangesAsync();
                    if(resultado>0)
                        return Unit.Value;
                    throw new Exception("No se guardaron los cambios en la persona seleccionad");
                }
            }

    }
}