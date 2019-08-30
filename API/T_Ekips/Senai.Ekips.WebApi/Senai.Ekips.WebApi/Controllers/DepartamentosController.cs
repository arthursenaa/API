using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentosController : Controller
    {

        DepartamentosRepository DepartamentosRepository = new DepartamentosRepository();


        [Authorize]
        [HttpGet]
        public IActionResult ListarDepartamentos()
        {
            return Ok(DepartamentosRepository.ListarDepartamentos());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(DepartamentosRepository.ListarPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Departamento departamento)
        {
            try
            {
                FuncionariosRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar." + ex.Message });
            }
        }
    }
}