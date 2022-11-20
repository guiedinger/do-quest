using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Entities.Validators;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;

namespace Do.Quest.Domain.Services
{
    public class GrupoUsuarioService : BaseService, IGrupoUsuarioService
    {
        private readonly IUserRepository _userRepository;

        public GrupoUsuarioService(IUserRepository userRepository, 
                                   INotificador notificador) 
                                   : base (notificador)
        {
            _userRepository = userRepository;
        }

        public async Task<string> AdicionarAsync(GrupoUsuario grupoUsuario)
        {
            if (!EstaValido(grupoUsuario)) 
                return null;

            await _userRepository.AdicionarGrupoUsuariosAsync(grupoUsuario);
            
            return grupoUsuario.Id.ToString();
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            if (usuario?.GrupoUsuario?.Id is null)
                return;
         
            var grupoUsuario = await _userRepository.ObterGrupoUsuariosAsync(usuario.GrupoUsuario.Id);
            
            if (grupoUsuario is null)
                Notificar("Grupo de usuários não encontrado.");

            if (TemNotificacao())
                return;

            if (grupoUsuario.AdicionarUsuario(usuario))
                await _userRepository.AtualizarGrupoUsuariosAsync(grupoUsuario);
        }

        public async Task<IEnumerable<GrupoUsuario>> ListarAsync()
        {
            return await _userRepository.ListarGruposUsuariosAsync();
        }

        private bool EstaValido(GrupoUsuario grupoUsuario)
        {
            return ExecutarValidacao(new GrupoUsuarioValidator(), grupoUsuario);
        }
    }
}
