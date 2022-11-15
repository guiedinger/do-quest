using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Services
{
    public interface IGrupoUsuarioService
    {
        Task<string> AdicionarAsync(GrupoUsuario grupoUsuario);
    }
}
