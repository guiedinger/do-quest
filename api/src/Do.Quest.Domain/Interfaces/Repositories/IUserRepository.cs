using Do.Quest.Domain.Entities;


namespace Do.Quest.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Login(Usuario usuario);
        Task Cadastro(Usuario usuario);
        Usuario? Find(Usuario user);
    }
}
