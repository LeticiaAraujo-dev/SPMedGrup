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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_medicoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(MedicoDomain novoMedico)
        {
            if (novoMedico.NomeMedico == null)
            {
                return BadRequest("O nome é obrigatório!");

            } if (novoMedico.CRM == null)
            {
                return BadRequest("O CRM é obrigatório!");

            } 
            return Created("http://localhost:44696/api/Medico", novoMedico);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MedicoDomain MedicoBuscado = _medicoRepository.BuscarPorId(id);

            if (MedicoBuscado != null)
            {
                return Ok(MedicoBuscado);
            }

            return NotFound("Nenhum Medico encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MedicoDomain MedicoAtualizado)
        {
            MedicoDomain MedicoBuscado = _medicoRepository.BuscarPorId(id);
            if (MedicoBuscado != null)
            {
                _medicoRepository.Atualizar(id, MedicoAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum medico encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            MedicoDomain MedicoBuscado = _medicoRepository.BuscarPorId(id);

            if (MedicoBuscado != null)
            {
                _medicoRepository.Deletar(id);

                return Ok($"O medico {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum medico encontrado para o identificador informado");
        }
    }
}
