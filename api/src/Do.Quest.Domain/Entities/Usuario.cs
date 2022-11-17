namespace Do.Quest.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome{ get; private set; }
        public DateTime DataNascimento { get; private set; }
        public GrupoUsuario GrupoUsuario { get; private set; }
        public bool RespondeuAoQuestionario{ get; private set; }
        public bool IsAdmin { get; private set; }

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
    }
}
