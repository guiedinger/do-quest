using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Enums;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Metadata;

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

		public async Task CadastrarOuAtualizar(Questionario questionario) {

            var quest = _questionarioContext.Questionario.AsQueryable().FirstOrDefault(x => x.Id == questionario.Id);

            if(quest != null)
            {
                
                await _questionarioContext.Questionario.ReplaceOneAsync(b => b.Id == questionario.Id, questionario);

            }
            else
            {
                await _questionarioContext.Questionario.InsertOneAsync(questionario);

            }
        }
	}
}
