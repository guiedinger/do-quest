using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;
using MongoDB.Driver;
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
        
        public Usuario? Find(Usuario usuario)
        {
            return _questionarioContext.Usuarios.AsQueryable().FirstOrDefault(x => x.Login == usuario.Login && x.Senha == usuario.Senha);
        }

        public Task<List<Usuario>> GetUsuarios()
        {
            return _questionarioContext.Usuarios.Find(_ => true).ToListAsync();

        }
    }
}
