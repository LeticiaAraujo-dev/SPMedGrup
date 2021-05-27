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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicasRepository { get; set; }

        public ClinicaController()
        {
            _clinicasRepository = new ClinicaRepository();
        }
        public IActionResult Get()
        {
            return Ok(_clinicasRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(ClinicaDomain novaClinica)
        {
            if (novaClinica.cnpj == null)
            {
                return BadRequest("O cnpj da clinica é obrigatório!");

            } if (novaClinica.nomeFantasia == null)
            {
                return BadRequest("O nome da clinica é obrigatório!");

            } if (novaClinica.RazaoSocial == null)
            {
                return BadRequest("O nome da clinica é obrigatório!");
            }
            _clinicasRepository.Cadastrar(novaClinica);

            return Created("http://localhost:44696/api/Clinica", novaClinica);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClinicaDomain ClinicaBuscada = _clinicasRepository.BuscarPorId(id);

            if (ClinicaBuscada != null)
            {
                return Ok(ClinicaBuscada);
            }

            return NotFound("Nenhuma clinica encontrada para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ClinicaDomain ClinicaAtualizada)
        {
            ClinicaDomain ClinicaBuscada = _clinicasRepository.BuscarPorId(id);
            if (ClinicaBuscada != null)
            {
                _clinicasRepository.Atualizar(id, ClinicaAtualizada);

                return StatusCode(204);
            }
            return NotFound("Nenhuma clinica encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ClinicaDomain ClinicaBuscada = _clinicasRepository.BuscarPorId(id);

            if (ClinicaBuscada != null)
            {
                _clinicasRepository.Deletar(id);

                return Ok($"A clinica {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhuma clinica encontrada para o identificador informado");
        }
    }
}
