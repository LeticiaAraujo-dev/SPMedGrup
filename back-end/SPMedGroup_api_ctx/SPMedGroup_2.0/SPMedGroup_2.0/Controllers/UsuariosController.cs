using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmedgroup.Interfaces;
using SPMedGroup_2._0.Domains;
using SPMedGroup_2._0.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmedgroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuarioRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_usuariosRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            if (novoUsuario.Email == null)
            {
                return BadRequest("O email é obrigatório!");

            }
            if (novoUsuario.Senha == null)
            {
                return BadRequest("A senha é obrigatória!");

            }
            return Created("http://localhost:5000/api/Usuarios", novoUsuario);
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuariosRepository.Login(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmdegroup-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(
                issuer: "senai_spmdegroup.webApi",
                audience: "senai_spmdegroup.webApi",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario UsuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                return Ok(UsuarioBuscado);
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = _usuariosRepository.BuscarPorId(id);
            if (UsuarioBuscado != null)
            {
                _usuariosRepository.Atualizar(id, UsuarioAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario UsuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                _usuariosRepository.Deletar(id);

                return Ok($"O usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }


    }
}
