using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;
using Do.Quest.Infra.Data.Extensions;
using MongoDB.Driver;

namespace Do.Quest.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuestionarioContext _questionarioContext;

        public UserRepository(QuestionarioContext questionarioContext)
        {
            _questionarioContext = questionarioContext;
        }

        public async Task AdicionarGrupoUsuariosAsync(GrupoUsuario grupoUsuario)
        {
            await _questionarioContext.GruposUsuarios.InsertOneAsync(grupoUsuario);
        }

        public async Task<GrupoUsuario> ObterGrupoUsuariosAsync(Guid id)
        {
            return await _questionarioContext.GruposUsuarios.FirstOrDefaultAsync(gu => gu.Id.Equals(id));
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            await _questionarioContext.Usuarios.ReplaceOneAsync(r => r.Id.Equals(usuario.Id), usuario);
        }

        public async Task CadastroAsync(Usuario usuario)
        {
            await _questionarioContext.Usuarios.InsertOneAsync(usuario);
        }
        
        public Usuario? Find(Usuario usuario)
        {
            return _questionarioContext.Usuarios
                .AsQueryable()
                .FirstOrDefault(x => x.Login == usuario.Login && x.Senha == usuario.Senha);
        }

        public async Task<Usuario> FindByLoginAsync(string login)
        {
            return await _questionarioContext.Usuarios.FirstOrDefaultAsync(u => u.Login.Equals(login));
        }

        public Usuario? Find(Guid id)
        {
            return _questionarioContext.Usuarios
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            return _questionarioContext.Usuarios.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<GrupoUsuario>> ListarGruposUsuariosAsync()
        {
            return await _questionarioContext.GruposUsuarios.ToListAsync();
        }

        public async Task AtualizarGrupoUsuariosAsync(GrupoUsuario grupoUsuario)
        {
            await _questionarioContext.GruposUsuarios.ReplaceOneAsync(r => r.Id.Equals(grupoUsuario.Id), grupoUsuario);
        }
    }
}
