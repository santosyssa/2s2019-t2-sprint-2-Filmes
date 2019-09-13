using Microsoft.AspNetCore.Mvc;
using Senai.FilmesWebApi.Domains;
using Senai.FilmesWebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.FilmesWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTodos()
        {
            return GeneroRepository.Listar();
        }

        [HttpGet ("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            GeneroDomain generoDomain = GeneroRepository.BuscarPorId(id);
            if (generoDomain == null)
            {
                return NotFound();
            }
            return Ok(generoDomain);
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            GeneroRepository.Cadastrar(generoDomain);
            return Ok();
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar(GeneroDomain generoDomain)
        {
            GeneroRepository.Atualizar(generoDomain);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
            
        }

    }
}
