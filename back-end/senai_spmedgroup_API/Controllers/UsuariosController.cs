using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using senai_spmedgroup.Repository;
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
            _usuariosRepository = new UsuariosRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_usuariosRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(UsuariosDomain novoUsuario)
        {
            if (novoUsuario.email == null)
            {
                return BadRequest("O email é obrigatório!");

            } if (novoUsuario.senha == null)
            {
                return BadRequest("A senha é obrigatória!");

            }
            return Created("http://localhost:44696/api/Usuarios", novoUsuario);
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuariosDomain login)
        {
            UsuariosDomain usuarioBuscado = _usuariosRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.idTipoUsuario.ToString()),
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
            UsuariosDomain UsuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                return Ok(UsuarioBuscado);
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuariosDomain UsuarioAtualizado)
        {
            UsuariosDomain UsuarioBuscado = _usuariosRepository.BuscarPorId(id);
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
            UsuariosDomain UsuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                _usuariosRepository.Deletar(id);

                return Ok($"O usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }


    }
}
