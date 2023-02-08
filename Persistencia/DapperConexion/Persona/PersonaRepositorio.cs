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
        public async Task<int> Actualizar(int id, string Nombres, string Apellidos, string Identificacion, DateTime Fecha_de_Nacimiento,int tipo_id)
        {
             var storeProcedure = "persona_editar";
            try
            {

                var connection = _factoryConnection.GetDbConnection();
                var resultados = await connection.ExecuteAsync(
                    storeProcedure,
                    new
                    {
                        id = id,
                        Nombres = Nombres,
                        Apellidos = Apellidos,
                        Identificacion = Identificacion,
                        Fecha_de_Nacimiento = Fecha_de_Nacimiento,
                        tipo_id = tipo_id
                    },
                    commandType: CommandType.StoredProcedure
                );

                _factoryConnection.CloseConnection();
                return resultados;

            }
            catch (Exception e)
            {
                throw new Exception("No se pudo editar la data de la persona", e);
            }

        }

        public async Task<int> Elimina(int id)
        {
             var storeProcedure = "persona_eliminar";
            try
            {
                var connection = _factoryConnection.GetDbConnection();
                var resultado = await connection.ExecuteAsync(
                    storeProcedure,
                    new
                    {
                        id = id
                    },
                    commandType: CommandType.StoredProcedure
                );
                _factoryConnection.CloseConnection();
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo eliminar la persona",e);
            }
        }

        public async Task<int> Nuevo(string Nombres, string Apellidos, string Identificacion, DateTime Fecha_de_Nacimiento,int tipo_id )
        {
            var storeProcedure = "persona_registrar";
            try{
                var connection = _factoryConnection.GetDbConnection();
                var resultado = await connection.ExecuteAsync(
                    storeProcedure, new
                    {
                        Nombres= Nombres,
                        Apellidos = Apellidos,
                        Identificacion = Identificacion,
                        Fecha_de_Nacimiento = Fecha_de_Nacimiento,
                        tipo_id = tipo_id

                    },
                    commandType: CommandType.StoredProcedure
                );     
                    _factoryConnection.CloseConnection();

                    return resultado;
               
                
            }catch(Exception e){
                throw  new Exception("Error en la Consulta de datos",e);
            }
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