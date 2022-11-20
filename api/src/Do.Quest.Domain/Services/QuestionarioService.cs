using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;

namespace Do.Quest.Domain.Services
{
    public class QuestionarioService : BaseService, IQuestionarioService
    {

      private readonly IQuestionarioRepository _questionarioRepository;

      public QuestionarioService(IQuestionarioRepository questionarioRepository,
                                 INotificador notificador): base(notificador) 
      {
            
            _questionarioRepository = questionarioRepository;
      }

        public async Task AddUpdateAsync(Questionario questionario)
        {
            await _questionarioRepository.CadastrarOuAtualizar(questionario);
        }

        public Task GetAsync(GrupoUsuario grupoUsuario)
        {
            return _questionarioRepository.GetAsync(grupoUsuario);

        }

        public Questionario? GetQuestionario(Guid idQuestionario)
        {
            return _questionarioRepository.GetQuestionario(idQuestionario);
        }
    }
}
