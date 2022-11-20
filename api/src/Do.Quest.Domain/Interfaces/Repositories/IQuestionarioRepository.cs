using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Repositories
{
   public interface IQuestionarioRepository {
      Task CadastrarOuAtualizar(Questionario questionario);
      Questionario? GetQuestionario(Guid idQuestionario);
      Task GetAsync(GrupoUsuario grupoUsuario);
    }
}
