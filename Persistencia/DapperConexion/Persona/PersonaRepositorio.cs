using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistencia.DapperConexion.Persona
{
    public class PersonaRepositorio : IPersona
    {
        private readonly IFactoryConnection _factoryConnection;
         public PersonaRepositorio(IFactoryConnection factoryConnection){
            _factoryConnection = factoryConnection;
         }
        public Task<int> Actualizar(PersonaModel parametros)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Elimina(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Nuevo(PersonaModel parametros)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<PersonaModel>> ObtenerLista()
        {
            IEnumerable<PersonaModel> personaLis = null;
            var storeProcedure = "persona_listar";
            try{
                var connection =_factoryConnection.GetDbConnection();
               personaLis = await connection.QueryAsync<PersonaModel>(storeProcedure,null,commandType : CommandType.StoredProcedure);
            }catch(Exception e){
                throw  new Exception("Error en la Consulta de datos",e);
            }finally{
                _factoryConnection.CloseConnection();
            }
            return personaLis;
        }

        public Task<PersonaModel> ObtenerPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}