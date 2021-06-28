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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_especialidadeRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(EspecialidadeDomain novaEspecialidade)
        {
            if (novaEspecialidade.NomeEspecialidade == null)
            {
                return BadRequest("O especialidade é obrigatório!");

            }
            return Created("http://localhost:5000/api/Especialidade", novaEspecialidade);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EspecialidadeDomain EspecialidadeBuscada = _especialidadeRepository.BuscarPorId(id);

            if (EspecialidadeBuscada != null)
            {
                return Ok(EspecialidadeBuscada);
            }

            return NotFound("Nenhuma Especialidade encontrada para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EspecialidadeDomain EspecialidadeAtualizada)
        {
            EspecialidadeDomain EspecialidadeBuscada = _especialidadeRepository.BuscarPorId(id);
            if (EspecialidadeBuscada != null)
            {
                _especialidadeRepository.Atualizar(id, EspecialidadeAtualizada);

                return StatusCode(204);
            }
            return NotFound("Nenhuma especialidade encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EspecialidadeDomain EspecialidadeBuscada = _especialidadeRepository.BuscarPorId(id);

            if (EspecialidadeBuscada != null)
            {
                _especialidadeRepository.Deletar(id);

                return Ok($"A especialidade {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhuma especialidade encontrada para o identificador informado");
        }
    }
}
