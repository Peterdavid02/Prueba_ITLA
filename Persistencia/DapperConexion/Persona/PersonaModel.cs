using System;

namespace Persistencia.DapperConexion.Persona
{
    public class PersonaModel
    {
        public int id {get;set;}
         public string Nombres {get;set;}
         
        public string Apellidos { get; set; }

        public string Identificacion { get; set; }

        public DateTime Fecha_de_Nacimiento { get; set; }

        public string tipo_id { get; set; }
    }
}