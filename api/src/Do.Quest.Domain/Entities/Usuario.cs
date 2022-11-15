using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome{ get; private set; }
        public DateTime DataNascimento { get; private set; }
        public GrupoUsuario GrupoUsuario { get; private set; }

        private Usuario() { }

        public Usuario(string login, string senha, string nome, string sobrenome, DateTime dataNascimento)
        {
            Id = Guid.NewGuid();
            Login = login;
            Senha = senha;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }
    }
}
