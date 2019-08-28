using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Repositories;

namespace $safeprojectname$.Controllers
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
    }
}