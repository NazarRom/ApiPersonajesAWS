using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajeContext context;

        public RepositoryPersonajes(PersonajeContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
           return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task InsertPersonajeAsync(int id, string nombre, string imagen)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = id;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            await this.context.Personajes.AddAsync(personaje);
            await this.context.SaveChangesAsync();

        }
    }
}
