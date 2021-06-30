using Microsoft.AspNetCore.Mvc;
using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using senai_spmedgroup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_pacienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(PacienteDomain novoPaciente)
        {
            if (novoPaciente.NomePaciente == null)
            {
                return BadRequest("O nome é obrigatório!");

            }
            return Created("http://localhost:44696/api/Paciente", novoPaciente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PacienteDomain PacienteBuscado = _pacienteRepository.BuscarPorId(id);

            if (PacienteBuscado != null)
            {
                return Ok(PacienteBuscado);
            }

            return NotFound("Nenhum Paciente encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PacienteDomain PacienteAtualizado)
        {
            PacienteDomain PacienteBuscado = _pacienteRepository.BuscarPorId(id);
            if (PacienteBuscado != null)
            {
                _pacienteRepository.Atualizar(id, PacienteAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum paciente encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PacienteDomain PacienteBuscado = _pacienteRepository.BuscarPorId(id);

            if (PacienteBuscado != null)
            {
                _pacienteRepository.Deletar(id);

                return Ok($"O paciente {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum paciente encontrado para o identificador informado");
        }
    }
}
