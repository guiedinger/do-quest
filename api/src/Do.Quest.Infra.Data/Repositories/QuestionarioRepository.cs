using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;

namespace Do.Quest.Infra.Data.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private readonly QuestionarioContext _questionarioContext;

        public QuestionarioRepository(QuestionarioContext questionarioContext)
        {
            _questionarioContext = questionarioContext;
        }

        public async Task AdicionarGrupoUsuariosAsync(GrupoUsuario grupoUsuario)
        {
            await _questionarioContext.GruposUsuarios.InsertOneAsync(grupoUsuario);
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
           await _questionarioContext.Usuarios.InsertOneAsync(usuario);
        }

        public async Task AdicionarUsuariosAsync(IEnumerable<Usuario> usuarios)
        {
            await _questionarioContext.Usuarios.InsertManyAsync(usuarios);
        }
    }
}
