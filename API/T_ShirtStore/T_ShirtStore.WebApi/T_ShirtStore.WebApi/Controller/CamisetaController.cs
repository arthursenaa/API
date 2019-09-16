using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_ShirtStore.WebApi.Domains;
using T_ShirtStore.WebApi.Repositories;

namespace T_ShirtStore.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class CamisetaController : ControllerBase
    {
        CamisetaRepository CamisetaRepository = new CamisetaRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CamisetaRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Camisa camisa)
        {
            try
            {
                if (camisa == null)
                {
                    return NotFound();
                }
                CamisetaRepository.Atualizar(camisa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro. Aguarde um momento. " + ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Camisa camisa)
        {
            try
            {
                CamisetaRepository.Cadastrar(camisa);
                return Ok();
            }
            catch (Exception ex)
            {
                    

                return BadRequest(new { mensagem = "Erro ao Cadastrar. Aguarde um momento. " + ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CamisetaRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("Tamanho")]
        public IActionResult ListarTamanho()
        {
            return Ok(CamisetaRepository.ListarTamanho());
        }
    }
}