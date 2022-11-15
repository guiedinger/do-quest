using Do.Quest.Api.Mappers;
using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Do.Quest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionarioController : MainController
    {
        private readonly ILogger<QuestionarioController> _logger;
        private readonly IGrupoUsuarioService _grupoUsuarioService;

        public QuestionarioController(ILogger<QuestionarioController> logger, 
                                      IGrupoUsuarioService grupoUsuarioService,
                                      INotificador notificador) : base(notificador)
        {
            _logger = logger;
            _grupoUsuarioService = grupoUsuarioService;
        }

        [HttpPost("grupo-usuario")]
        public async Task<ActionResult<string>> AdicionarGrupoUsuarioAsync(GrupoUsuarioViewModel grupoUsuarioRequest)
        {
            return Ok(await _grupoUsuarioService.AdicionarAsync(GrupoUsuarioMapper.Map(grupoUsuarioRequest)));
        }
    }
}