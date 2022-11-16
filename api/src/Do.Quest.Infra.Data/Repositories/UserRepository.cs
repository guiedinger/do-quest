using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuestionarioContext _questionarioContext;

        public UserRepository(QuestionarioContext questionarioContext)
        {
            _questionarioContext = questionarioContext;
        }
        public async Task Cadastro(Usuario usuario)
        {
            await _questionarioContext.Usuarios.InsertOneAsync(usuario);
        }

        public Task Login(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
