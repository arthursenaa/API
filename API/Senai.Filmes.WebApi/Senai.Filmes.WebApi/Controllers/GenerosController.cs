using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController
    {
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTudo()
        {
            return generoRepository.Listar();
        }
    }
}
