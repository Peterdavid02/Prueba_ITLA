using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Persona
{
    public interface IPersona
    {
         Task<IEnumerable<PersonaModel>> ObtenerLista();

         Task<PersonaModel> ObtenerPorId(int id);

        Task<int> Nuevo(PersonaModel parametros);

        Task<int> Actualizar(PersonaModel parametros);

        Task<int> Elimina(int id);

    }
}