using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;

namespace Do.Quest.Domain.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,
                           INotificador notificador) : base(notificador)
        {
            _userRepository = userRepository;
;
        }

        public async Task AdicionarAsync(Usuario user)
        {
            var usuario = _userRepository.Find(user);

            if (usuario is null)
                await _userRepository.CadastroAsync(user);

            Notificar($"O usuario {user.Login} já existe");
        }

        public async Task<Usuario> AtualizarAsync(Guid id, Usuario usuario)
        {
            var usuarioAtual = _userRepository.Find(id);

            if (usuarioAtual is null)
            {
                Notificar($"Impossível atualizar, pois não existe usuário cadastrado com o id: {id}.");
                return default;
            }

            var loginExistente = await _userRepository.FindByLoginAsync(usuario.Login) != null;
            if (!usuarioAtual.Login.Equals(usuario.Login) && loginExistente)
            {
                Notificar($"Impossível atualizar, pois o login {usuario.Login} já existe.");
                return default;
            }

            if (usuario.GrupoUsuarioId is not null)
            {
                var grupoUsuarios = await _userRepository.ObterGrupoUsuariosAsync(usuario.GrupoUsuarioId.Value);
                
                if (grupoUsuarios is null)
                {
                    Notificar($"Impossível atualizar, o grupo de usuários informado não existe.");
                    return default;
                }

                usuarioAtual.AtualizarGrupoUsuario(grupoUsuarios?.Id, grupoUsuarios);
            }
   
            AtualizarUsuario(usuarioAtual, usuario);
            
            await _userRepository.AtualizarAsync(usuarioAtual);

            return usuarioAtual;
        }

        public Usuario? Find(Usuario user)
        {
            var usuario = _userRepository.Find(user);

            if (usuario is not null)
                return usuario;

            Notificar($"O usuario {user.Login} não foi encontrado");
            return default;
        }

        public Task<List<Usuario>> GetUsuarios()
        {
           return _userRepository.GetUsuariosAsync();
        }

        private void AtualizarUsuario(Usuario usuarioAtual, Usuario usuarioAtualizado)
        {
            usuarioAtual.Login = usuarioAtualizado.Login;
            usuarioAtual.Senha = usuarioAtualizado.Senha;
            usuarioAtual.Nome = usuarioAtualizado.Nome;
            usuarioAtual.Sobrenome = usuarioAtualizado.Sobrenome;
            usuarioAtual.DataNascimento = usuarioAtualizado.DataNascimento;
            usuarioAtual.IsAdmin = usuarioAtualizado.IsAdmin;
        }
    }
}
