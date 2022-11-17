using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Repositories
{
   public interface IQuestionarioRepository {
      Task Cadastrar(Questionario questionario);
      Task AdicionarUsuarioAsync(Usuario usuario);
      Task AdicionarGrupoUsuariosAsync(GrupoUsuario grupoUsuario);
      Task AdicionarUsuariosAsync(IEnumerable<Usuario> usuarios);
   }
}
