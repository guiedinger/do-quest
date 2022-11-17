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

        public async Task<string> AdicionarAsync(Usuario user)
        {
            
            await _userRepository.Cadastro(user);
            return "cadastrado";

        }

        public Usuario? Find(Usuario user)
        {
            return _userRepository.Find(user);

        }
    }
}
