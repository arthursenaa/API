using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class EstilosController : Controller
    {

        EstilosRepository EstilosRepository = new EstilosRepository();


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstilosRepository.Listar());
        }
    }
}
