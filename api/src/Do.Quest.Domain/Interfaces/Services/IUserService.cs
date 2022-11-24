using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Usuario> AdicionarAsync(Usuario user);
        Task<Usuario> AtualizarAsync(Guid id, Usuario usuario);
        Usuario? Find(Usuario user);
        Usuario? Find(Guid userId);
        Task<List<Usuario>> GetUsuarios();

    }
}
