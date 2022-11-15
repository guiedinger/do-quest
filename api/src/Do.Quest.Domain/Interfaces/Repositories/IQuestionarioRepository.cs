using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Repositories
{
    public interface IQuestionarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task AdicionarGrupoUsuarios(GrupoUsuario grupoUsuario);
    }
}
