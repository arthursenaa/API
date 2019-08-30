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
    public class CargosController : Controller
    {
        CargosRepository CargosRepository = new CargosRepository();


        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CargosRepository.Listar());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(CargosRepository.ListarPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Cargo cargos)
        {
            try
            {
                CargosRepository.Cadastrar(cargos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar." + ex.Message });
            }
        }
    }
}