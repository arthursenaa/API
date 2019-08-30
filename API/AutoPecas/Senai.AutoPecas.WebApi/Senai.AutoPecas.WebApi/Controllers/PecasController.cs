using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController
    {

        PecasRepository PecasRepository = new PecasRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return OK(PecasRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult ListarId()
        {

        }
    }
}
