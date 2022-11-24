using Do.Quest.Api.Mappers;
using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Api.Models.Usuario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Services;
using Do.Quest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Do.Quest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserService _userService;
        private readonly IGrupoUsuarioService _grupoUsuarioService; 

        public UserController(IUserService usuarioService,
                              IGrupoUsuarioService grupoUsuarioService,
                              INotificador notificador) : base(notificador)
        {
            _userService = usuarioService;
            _grupoUsuarioService = grupoUsuarioService;
        }

        [HttpPost("grupo-usuario")]
        public async Task<ActionResult<string>> AdicionarGrupoUsuarioAsync(GrupoUsuarioViewModel grupoUsuarioRequest)
        {
            return Ok(await _grupoUsuarioService.AdicionarAsync(GrupoUsuarioMapper.Map(grupoUsuarioRequest)));
        }

        [HttpGet("grupo-usuario/lista")]
        public async Task<ActionResult<IEnumerable<GrupoUsuarioViewModel>>> ListarGruposUsuariosAsync()
        {
            return Ok(GrupoUsuarioMapper.Map(await _grupoUsuarioService.ListarAsync()));
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioViewModel>> Cadastro([FromBody] UsuarioViewModel user)
        {
            var usuario = await _userService.AdicionarAsync(UsuarioMapper.Map(user));

            return CustomResponse(UsuarioMapper.Map(usuario));
        }

        [HttpPut("cadastro/{usuarioId:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> AtualizarCadastroAsync([FromRoute] Guid usuarioId, 
                                                                                 [FromBody] UsuarioViewModel user)
        {
            if (!ModelState.IsValid) 
                return CustomResponse(ModelState);

            var usuario = await _userService.AtualizarAsync(usuarioId, UsuarioMapper.Map(user));

            return CustomResponse(UsuarioMapper.Map(usuario));
        }

        [HttpPost("login")]
        public ActionResult<Usuario> Login([FromBody] UsuarioViewLogin user)
        {
            var usuario = _userService.Find(UsuarioMapper.MapLogin(user));

            return CustomResponse(usuario);
        }

        [HttpGet("usuarios")]
        public ActionResult GetUsuarios()
        {
            var usuarios = _userService.GetUsuarios();

            return CustomResponse(usuarios.Result);
        }

        [HttpGet("usuario/{usuarioId:guid}")]
        public ActionResult<Usuario> GetUsuario([FromRoute] Guid usuarioId)
        {
            var usuario = _userService.Find(usuarioId);

            return CustomResponse(usuario);
        }
    }
}
