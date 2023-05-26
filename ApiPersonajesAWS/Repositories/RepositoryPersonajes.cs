using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

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

        public async Task InsertWithProcedureAsync(string nombre, string imagen)
        {
            string sql = "CALL sp_insert_personaje (@nombre, @imag)";
            MySqlParameter pamnombre = new MySqlParameter("@nombre", nombre);
            MySqlParameter pamimag = new MySqlParameter("@imag", imagen);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamnombre, pamimag);
        }

        public async Task UpdateWithProcedureAsync(int id, string nombre, string imagen)
        {
            string sql = "CALL sp_update_personaje (@id,@nombre, @imag)";
            MySqlParameter pamid = new MySqlParameter("@id", id);
            MySqlParameter pamnombre = new MySqlParameter("@nombre", nombre);
            MySqlParameter pamimag = new MySqlParameter("@imag", imagen);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamid, pamnombre, pamimag);
        }

        public async Task DeletewithProcedureAsync(int id)
        {
            string sql = "CALL sp_delete_personaje (@id)";
            MySqlParameter pamid = new MySqlParameter("@id", id);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamid);
        }
    }
}
