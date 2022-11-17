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
                                   INotificador notificador)
                                   : base(notificador)
        {
            _userRepository = userRepository;
;
        }

        public async Task AdicionarAsync(Usuario user)
        {
            var usuario = _userRepository.Find(user);

            if (usuario == null)
            {
          
                await _userRepository.Cadastro(user);

            }
            else
            {
                Notificar($"O usuario {user.Login} já existe");
            }



        }

        public Usuario? Find(Usuario user)
        {
            var usuario = _userRepository.Find(user);

            if (usuario == null) 
            {
                Notificar($"O usuario { user.Login} não foi encontrado");
                return null;

            }
            else
            {
                return usuario;
            }


        }

    }
}
