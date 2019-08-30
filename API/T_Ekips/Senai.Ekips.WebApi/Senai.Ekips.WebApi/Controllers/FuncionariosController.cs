using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using Senai.Ekips.WebApi.ViewModel;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : Controller
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();
        LoginRepositorio LoginRepositorio = new LoginRepositorio();


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

        //[Authorize]
        //[HttpGet]
        //public IActionResult BuscarPorEmailESenha(LoginViewModel login)
        //{
        //    if (Usuario.IdPermissaoNavigation.Equals(1))
        //    {
        //        return Ok(FuncionariosRepository.Listar());
        //    }
        //
        //
        //}




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