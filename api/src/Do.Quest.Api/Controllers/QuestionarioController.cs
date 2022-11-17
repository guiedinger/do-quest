using Do.Quest.Api.Mappers;
using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Api.Models.Questionario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Services;
using Do.Quest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Do.Quest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionarioController : MainController
    {
        private readonly ILogger<QuestionarioController> _logger;
        private readonly IGrupoUsuarioService _grupoUsuarioService;
        private readonly IQuestionarioService _questionarioService;


        public QuestionarioController(ILogger<QuestionarioController> logger, 
                                      IGrupoUsuarioService grupoUsuarioService, IQuestionarioService questionarioService,
                                      INotificador notificador) : base(notificador)
        {
            _logger = logger;
            _grupoUsuarioService = grupoUsuarioService;
            _questionarioService = questionarioService;
        }

        [HttpGet("retorna-questionario")]
        public async Task<ActionResult> Get (GrupoUsuario grupoUsuario) {
            await _questionarioService.GetAsync(grupoUsuario);
            return Ok();
        }

        [HttpPost("grupo-usuario")]
        public async Task<ActionResult<string>> AdicionarGrupoUsuarioAsync(GrupoUsuarioViewModel grupoUsuarioRequest)
        {
            return Ok(await _grupoUsuarioService.AdicionarAsync(GrupoUsuarioMapper.Map(grupoUsuarioRequest)));
        }

        [HttpPost("questionario")]
        public async Task<ActionResult<Questionario>> AddUpdateQuestionario(QuestionarioViewModel questionarioRequest)
        {
            await _questionarioService.AddUpdateAsync(QuestionarioMapper.Map(questionarioRequest));
            return Ok();
        }
    }
}