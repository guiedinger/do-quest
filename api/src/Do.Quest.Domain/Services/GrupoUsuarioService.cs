using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Entities.Validators;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;

namespace Do.Quest.Domain.Services
{
    public class GrupoUsuarioService : BaseService, IGrupoUsuarioService
    {
        private readonly IUserRepository _userRepositoryRepository;

        public GrupoUsuarioService(IUserRepository userRepository, 
                                   INotificador notificador) 
                                   : base (notificador)
        {
            _userRepositoryRepository = userRepository;
        }

        public async Task<string> AdicionarAsync(GrupoUsuario grupoUsuario)
        {
            if (!EstaValido(grupoUsuario)) 
                return null;

            await _userRepositoryRepository.AdicionarGrupoUsuariosAsync(grupoUsuario);
            
            return grupoUsuario.Id.ToString();
        }

        public async Task<IEnumerable<GrupoUsuario>> ListarAsync()
        {
            return await _userRepositoryRepository.ListarGruposUsuariosAsync();
        }

        private bool EstaValido(GrupoUsuario grupoUsuario)
        {
            return ExecutarValidacao(new GrupoUsuarioValidator(), grupoUsuario);
        }
    }
}
