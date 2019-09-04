using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;


namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private IFornecedorRepository FornecedorRepository { get; set; }
        public FornecedorController()
        {
            FornecedorRepository = new FornecedorRepository();
        }



        [HttpPost]
        public IActionResult Cadastrar(Fornecedor fornecedor)
        {
            try
            {
                fornecedor.IdFornecedor = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                FornecedorRepository.CadastrarFornecedor(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar" + ex.Message });
            }
        }
    }
}
