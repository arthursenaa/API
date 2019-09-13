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
    public class MarcasController : ControllerBase
    {

        MarcasRepository MarcasRepository = new MarcasRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(MarcasRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Empresa empresa)
        {
            try
            {
                if (empresa == null)
                {
                    return NotFound();
                }
                MarcasRepository.Atualizar(empresa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro. Aguarde um momento. " + ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Empresa empresa)
        {
            try
            {
                MarcasRepository.Cadastrar(empresa);
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
            MarcasRepository.Deletar(id);
            return Ok();
        }
    }
}