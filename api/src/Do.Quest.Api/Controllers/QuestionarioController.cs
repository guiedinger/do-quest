using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Do.Quest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionarioController : ControllerBase
    {
        private readonly ILogger<QuestionarioController> _logger;
        private readonly IGrupoUsuarioService _grupoUsuarioService;

        public QuestionarioController(ILogger<QuestionarioController> logger, IGrupoUsuarioService grupoUsuarioService)
        {
            _logger = logger;
            _grupoUsuarioService = grupoUsuarioService;
        }

        [HttpPost]
        public async Task AdicionarGrupoUsuarioAsync(GrupoUsuarioViewModel grupoUsuarioRequest)
        {
            await _grupoUsuarioService.AdicionarAsync(new GrupoUsuario(grupoUsuarioRequest.Descricao));
        }
    }
}