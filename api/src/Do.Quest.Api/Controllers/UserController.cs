using Do.Quest.Api.Mappers;
using Do.Quest.Api.Models.Usuario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Services;
using Do.Quest.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Do.Quest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserService _userService;


        public UserController(IUserService usuarioService, INotificador notificador) : base(notificador)
        {
            _userService = usuarioService;
        }


        [HttpPost("cadastro")]
        public ActionResult Cadastro([FromBody] UsuarioViewModel user)
        {
            var usuario = _userService.AdicionarAsync(UsuarioMapper.Map(user));

            return CustomResponse(usuario);

        }

        [HttpPost("login")]
        public ActionResult<Usuario> Login([FromBody] UsuarioViewLogin user)
        {
            var usuario = _userService.Find(UsuarioMapper.MapLogin(user));


            return CustomResponse(usuario);


        }


    }
}
