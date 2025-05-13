using ApiPersonajesAWS.Models;
using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repository;
        public PersonajesController(RepositoryPersonajes repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repository.GetPersonajes();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Personaje personaje)
        {
            await this.repository.CreatePersonajeAsync(personaje.Nombre, personaje.Imagen);
            return Ok();
        }

    }
}
