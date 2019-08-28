using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Domains;
using $safeprojectname$.Repositories;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : Controller
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();


        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            //Usuario usuario = new Usuario();

            //if (usuario.IdPermissaoNavigation.Equals(1))
            //{
                return Ok(FuncionariosRepository.Listar());   
            //}
            //else
            //{
            //    return Ok(FuncionariosRepository.Listar());
            //}
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            try
            {
                FuncionariosRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar." + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Funcionario funcionario)
        {
            funcionario.IdFuncionario = id;
            FuncionariosRepository.Atualizar(funcionario);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario Funcionario = ctx.Funcionario.Find(id);
                ctx.Funcionario.Remove(Funcionario);
                ctx.SaveChanges();
            }
        }
    }
}