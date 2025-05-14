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
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
            var personaje = await this.repository.GetPersonaje(id);
            if (personaje == null)
            {
                return NotFound();
            }
            return personaje;
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, string nombre, string imagen)
        {
            await this.repository.UpdatePersonajeAsync(id, nombre, imagen);
            return Ok();
        }

    }
}
