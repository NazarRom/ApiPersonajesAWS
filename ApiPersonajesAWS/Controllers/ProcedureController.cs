using ApiPersonajesAWS.Models;
using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public ProcedureController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }


        [HttpPost]
        public async Task<ActionResult> InsertPersonajeProcedure(Personaje personaje)
        {
            await this.repo.InsertWithProcedureAsync(personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonajeProcedure(Personaje personaje)
        {
            await this.repo.UpdateWithProcedureAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePersonajeProcedure(int id)
        {
            await this.repo.DeletewithProcedureAsync(id);
            return Ok();
        }
    }
}
