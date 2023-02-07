using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Persistencia
{
    public class personasContext : DbContext
    {
        public personasContext(DbContextOptions options) : base(options){

        }

        public DbSet<persona> persona {get;set;}
        public DbSet<Tipo_de_identificación> Tipo_de_identificación {get;set;}
    }
}