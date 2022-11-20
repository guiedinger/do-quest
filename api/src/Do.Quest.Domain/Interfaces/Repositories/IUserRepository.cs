using Do.Quest.Domain.Entities;


namespace Do.Quest.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task CadastroAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Usuario? Find(Usuario user);
        Usuario? Find(Guid id);
        Task<Usuario> FindByLoginAsync(string login);
        Task<List<Usuario>> GetUsuariosAsync();
        Task AdicionarGrupoUsuariosAsync(GrupoUsuario grupoUsuario);
        Task<GrupoUsuario> ObterGrupoUsuariosAsync(Guid id);
        Task<IEnumerable<GrupoUsuario>> ListarGruposUsuariosAsync();

    }
}
