using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {

        //PecasRepository PecasRepository = new PecasRepository();
        private IPecasRepository PecasRepository { get; set; }

        public PecasController()
        {
            PecasRepository = new PecasRepository();
        }



        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarId(int id)
        {
            return Ok(PecasRepository.ListarId(id));
        }

        [HttpPut]
        public IActionResult Atualizar(Pecas pecas)
        {
            try
            {
                PecasRepository.AtualizarPeca(pecas);
                if (pecas == null)
                {
                    return NotFound();
                }
                PecasRepository.AtualizarPeca(pecas);
                return Ok();              
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar" + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar (Pecas pecas)
        {
            try
            {
                pecas.IdFornecedor = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                PecasRepository.CadastrarPeca(pecas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar" +  ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecasRepository.DeletarPeca(id);
            return Ok();
        }
    }
}
