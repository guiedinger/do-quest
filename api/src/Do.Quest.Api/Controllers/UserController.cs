using Do.Quest.Api.Mappers;
using Do.Quest.Api.Models.Usuario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Do.Quest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService usuarioService)
        {
            _userService = usuarioService;
        }


        [HttpPost("cadastro")]
        public async Task<ActionResult<string>> Cadastro([FromBody] UsuarioViewModel user)
        {
            return Ok(await _userService.AdicionarAsync(UsuarioMapper.Map(user)));

        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] UsuarioViewLogin user)
        {
            Usuario? usuario = _userService.Find(UsuarioMapper.MapLogin(user));

       
            return Ok(usuario);

        }


    }
}
