using Do.Quest.Api.Mappers;
using Do.Quest.Api.Models.Questionario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Do.Quest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionarioController : MainController
    {
        private readonly ILogger<QuestionarioController> _logger;
        private readonly IQuestionarioService _questionarioService;


        public QuestionarioController(ILogger<QuestionarioController> logger, 
                                      IQuestionarioService questionarioService,
                                      INotificador notificador) : base(notificador)
        {
            _logger = logger;
            _questionarioService = questionarioService;
        }

        [HttpGet("retorna-questionario")]
        public async Task<ActionResult> Get (GrupoUsuario grupoUsuario) {
            await _questionarioService.GetAsync(grupoUsuario);
            return Ok();
        }

        [HttpGet("questionario/{id}")]
        public ActionResult GetQuestionarioById([FromRoute] Guid id)
        {
            var quest = _questionarioService.GetQuestionario(id);
            return Ok(quest);
        }

        [HttpPost("questionario")]
        public async Task<ActionResult<Questionario>> AddUpdateQuestionario(QuestionarioViewModel questionarioRequest)
        {
            await _questionarioService.AddUpdateAsync(QuestionarioMapper.Map(questionarioRequest));
            return Ok();
        }
    }

}