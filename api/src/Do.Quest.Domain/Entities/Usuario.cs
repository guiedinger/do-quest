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

        private Usuario() { }

        public Usuario(string login, 
                       string senha, 
                       string nome, 
                       string sobrenome, 
                       DateTime dataNascimento)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            RespondeuAoQuestionario = false;
        }

        public void DefinirQueRespondeuAoQuestionario()
        {
            RespondeuAoQuestionario = true;
        }
    }
}
