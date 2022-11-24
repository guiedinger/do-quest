namespace Do.Quest.Domain.Entities
{
    public class Usuario : Entity
    {
        public Guid? _Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome{ get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid? GrupoUsuarioId { get; private set; }
        public GrupoUsuario GrupoUsuario { get; private set; }
        public bool RespondeuAoQuestionario{ get; private set; }
        public bool IsAdmin { get; set; }

        private Usuario() { }

        public Usuario(string login, 
                       string senha, 
                       string nome, 
                       string sobrenome, 
                       DateTime dataNascimento, bool isAdmin)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            RespondeuAoQuestionario = false;
            IsAdmin = isAdmin;
        }

        public Usuario(Guid id)
        {
            _Id = id;
        }

        public Usuario(string login,
                       string senha)
        {
            Login = login;
            Senha = senha;
        }

        public void DefinirQueRespondeuAoQuestionario()
        {
            RespondeuAoQuestionario = true;
        }

        public void AtualizarGrupoUsuario(Guid? grupoUsuarioId, GrupoUsuario grupoUsuario)
        {
            GrupoUsuarioId = grupoUsuarioId;
            GrupoUsuario = grupoUsuario;
        }
    }
}
