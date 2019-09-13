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
    public class FilmesController : ControllerBase
    {
        FilmeRepository FilmeRepository = new FilmeRepository();

        [HttpGet]
        public IEnumerable<FilmeDomain> Listar()
        {
            return FilmeRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
    {
            FilmeDomain filmeDomain = FilmeRepository.BuscarPorId(id);
            if (filmeDomain == null)
            {
                return NotFound();
            }
            return Ok(filmeDomain);
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filmeDomain)
        {
            FilmeRepository.Cadastrar(filmeDomain);
            return Ok();
        }

    }
}
