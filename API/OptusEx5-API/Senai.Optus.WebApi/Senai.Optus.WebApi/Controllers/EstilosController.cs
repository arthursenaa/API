using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class EstilosController : Controller
    {

        EstilosRepository EstilosRepository = new EstilosRepository();


        // GET: /<controller>/
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstilosRepository.Listar());
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilos)
        {
            try
            {
                EstilosRepository.Cadastrar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar." + ex.Message });
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estilos estilos)
        {
            try
            {
                Estilos EstiloBuscado = EstilosRepository.BuscarPorId(estilos.IdEstilo);
                if (EstiloBuscado == null)
                    return NotFound();
                EstilosRepository.Atualizar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mesagem = "Erro ao Atualizar" });
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstilosRepository.Deletar(id);
            return Ok();
        }
    }
}
