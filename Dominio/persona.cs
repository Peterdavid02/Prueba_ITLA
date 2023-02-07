using System;
namespace Dominio
{

    public class persona
    {
        public int id {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Identificación {get;set;}
        public DateTime Fecha_de_Nacimiento {get;set;}

        public Tipo_de_identificación type {get;set;}
    }
}