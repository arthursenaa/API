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
    public class UsuarioController : ControllerBase
    {

        UsuarioRepository UsuarioRepository = new UsuarioRepository();


        //[Authorize]
        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario user)
        {
            try
            {
                UsuarioRepository.CadastrarUsuario(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar." + ex.Message });
            }
        }


        //[Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Usuario user)
        {
            try
            {
                if (user == null)
                {
                    return NotFound();
                }

                UsuarioRepository.Atualizar(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar." + ex.Message });
            }
        }

        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
                UsuarioRepository.Deletar(id);
                return Ok();
        }

    }
}