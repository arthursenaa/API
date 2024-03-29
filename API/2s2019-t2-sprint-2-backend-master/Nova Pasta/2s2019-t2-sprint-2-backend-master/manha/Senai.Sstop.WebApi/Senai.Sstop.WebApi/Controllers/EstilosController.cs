﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>()
        {
            new EstiloDomain { IdEstilo = 1, Nome = "Rock" }
            ,new EstiloDomain { IdEstilo = 2, Nome = "Pop" }
        };

        EstiloRepository EstiloRepository = new EstiloRepository();

        // GET /api/estilos
        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            // return estilos;
            return EstiloRepository.Listar();
        }

        // GET /api/estilos/1
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // lista fixa
            // EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);

            // do banco de dados
            EstiloDomain Estilo = EstiloRepository.BuscarPorId(id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        // POST /api/estilos
        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            // do banco de dados
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        // ATUALIZAR
        // PUT /api/estilos
        // { "idEstiloMusical" : "", "nome" : ""}
        // PUT /api/estilos/1 {"nome" : "Estilo A"}
        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }

        // DELETAR
        // DELETE /api/estilos/1009
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição Recebida";
        //}


    }
}