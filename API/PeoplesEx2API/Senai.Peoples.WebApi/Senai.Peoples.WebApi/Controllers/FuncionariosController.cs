using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : Controller
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository(); 

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<FuncionariosDomain> ListarFuncionarios()
        {
            return FuncionariosRepository.Listar();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionariosDomain funcionariosDomain = FuncionariosRepository.BuscarPorId(id);
            if (funcionariosDomain == null)
                return NotFound();
            return Ok(funcionariosDomain);
        }



        // POST api/<controller>
        [HttpPost]
        public IActionResult Cadastro(FuncionariosDomain funcionariosDomain)
        {
            FuncionariosRepository.Cadastrar(funcionariosDomain);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Atualizar(FuncionariosDomain funcionariosDomain)
        {
            FuncionariosRepository.Update(funcionariosDomain);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionariosRepository.Delete(id);
            return Ok();
        }
    }
}
