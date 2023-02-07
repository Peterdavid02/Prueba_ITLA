using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{

    public class persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombres { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellidos { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Identificación { get; set; }

        [Required]
        public DateTime Fecha_de_Nacimiento { get; set; }

        [Required]
        public int tipo_id { get; set; }

        [ForeignKey("tipo_id")]
        public Tipo_de_identificación Tipo_de_identificación { get; set; }
    }
}