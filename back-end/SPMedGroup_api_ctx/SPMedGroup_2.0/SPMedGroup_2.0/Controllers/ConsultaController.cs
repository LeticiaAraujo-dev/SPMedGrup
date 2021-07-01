using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using senai_spmedgroup.Interfaces;
using SPMedGroup_2._0.Domains;
using SPMedGroup_2._0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmedgroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_consultaRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(Consultum novaConsulta)
        {
            _consultaRepository.Cadastrar(novaConsulta);
            return Created("http://localhost:5000/api/Consulta", novaConsulta);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Consultum ConsultaBuscada = _consultaRepository.BuscarPorId(id);

            if (ConsultaBuscada != null)
            {
                return Ok(ConsultaBuscada);
            }

            return NotFound("Nenhuma consulta encontrada para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consultum ConsultaAtualizada)
        {
            Consultum ConsultaBuscada = _consultaRepository.BuscarPorId(id);
            if (ConsultaBuscada != null)
            {
                _consultaRepository.Atualizar(id, ConsultaAtualizada);

                return StatusCode(204);
            }
            return NotFound("Nenhuma clinica encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Consultum ConsultaBuscada = _consultaRepository.BuscarPorId(id);

            if (ConsultaBuscada != null)
            {
                _consultaRepository.Deletar(id);

                return Ok($"A consulta {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhuma consulta encontrada para o identificador informado");
        }

        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(id));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    error
                });
            }
        }
    }
}
