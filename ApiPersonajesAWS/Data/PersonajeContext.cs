using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Data
{
    public class PersonajeContext : DbContext
    {
        public PersonajeContext(DbContextOptions<PersonajeContext> options) : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
