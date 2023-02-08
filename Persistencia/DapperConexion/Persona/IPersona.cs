using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Persona
{
    public interface IPersona
    {
         Task<IEnumerable<PersonaModel>> ObtenerLista();

         Task<PersonaModel> ObtenerPorId(int id);

        Task<int> Nuevo(string Nombre, string Apellidos, string Identificacion, DateTime Fecha_de_Nacimiento,int tipo_id);

        Task<int> Actualizar(PersonaModel parametros);

        Task<int> Elimina(int id);

    }
}