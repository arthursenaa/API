using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistasController : Controller
    {

        ArtistasRepository ArtistasRepository = new ArtistasRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ArtistasRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Artistas artistas)
        {
            try
            {
                ArtistasRepository.Cadastrar(artistas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar." + ex.Message });
            }
        }
    }
}
