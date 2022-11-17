using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Domain.Services {
	public class QuestionarioService : BaseService, IQuestionarioService{

      private readonly IQuestionarioRepository _questionarioRepository;

      public QuestionarioService(IQuestionarioRepository questionarioRepository, INotificador notificador): base(notificador) {
         _questionarioRepository = questionarioRepository;
      }

        public async Task AddUpdateAsync(Questionario questionario)
        {
            await _questionarioRepository.CadastrarOuAtualizar(questionario);

        }

        public async Task<string> AdicionarAsync(Usuario usuario, GrupoUsuario grupoUsuario, IEnumerable<Usuario> usuarios) 
        {
         await _questionarioRepository.AdicionarUsuarioAsync(usuario);
         await _questionarioRepository.AdicionarGrupoUsuariosAsync(grupoUsuario);
         await _questionarioRepository.AdicionarUsuariosAsync(usuarios);
         return "cadastrado";
        }

	  //public async Task<string> AdicionarAsync(Questionario questionario) {
   //      await _questionarioRepository.Cadastrar(questionario);
   //      return "cadastrado";
   //   }
	}

}
