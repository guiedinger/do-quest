using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;
using MongoDB.Driver;

namespace Do.Quest.Infra.Data.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private readonly QuestionarioContext _questionarioContext;

        public QuestionarioRepository(QuestionarioContext questionarioContext)
        {
            _questionarioContext = questionarioContext;
        }

        public async Task CadastrarOuAtualizar(Questionario questionario)
        {

            var quest = _questionarioContext.Questionario.AsQueryable().FirstOrDefault(x => x.Id == questionario.Id);

            if (quest != null)
            {

                await _questionarioContext.Questionario.ReplaceOneAsync(b => b.Id == questionario.Id, questionario);

            }
            else
            {
                await _questionarioContext.Questionario.InsertOneAsync(questionario);
            }
        }

        public Task GetAsync(GrupoUsuario grupoUsuario)
        {
            return _questionarioContext.Usuarios.Find(x => x.GrupoUsuario.Id == grupoUsuario.Id).ToListAsync();

        }

        public List<Questionario> GetQuestionario(GrupoUsuario grupoUsuario)
        {
            List<Questionario> quest = null;

            foreach (var item in _questionarioContext.Questionario.AsQueryable())
            {
                foreach (var item2 in item.GruposUsuarios)
                {
                    if (item2.Id == grupoUsuario.Id)
                    {
                        quest.Add(item);
                        break;
                    } 
                }
            }

            return quest;
        }

        public Questionario? GetQuestionario(Guid idQuest)
        {
            var quest = _questionarioContext.Questionario.AsQueryable().FirstOrDefault(x => x.Id == idQuest);
            return quest;
        }
    }
}
