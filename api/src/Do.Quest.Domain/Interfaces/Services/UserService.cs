using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> AdicionarAsync(Usuario user);
    }
}
