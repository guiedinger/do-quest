using Do.Quest.Domain.Enums;

namespace Do.Quest.Domain.Entities
{
    public class Questionario : Entity
    {
        public string Descricao{ get; private set; }
        public DateTime DataInicio{ get; private set; }
        public DateTime DataFim{ get; private set; }
        public ESituacao Situacao{ get; private set; }
        public List<GrupoUsuario> GruposUsuarios{ get; private set; }
        public List<Pergunta> Perguntas{ get; private set; }

        private Questionario() { }

        public Questionario(string descricao, DateTime dataInicio, DateTime dataFim, List<GrupoUsuario> grupoUsuario, List<Pergunta> perguntas) {
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Situacao = ESituacao.Liberado;
            GruposUsuarios = grupoUsuario;
            Perguntas = perguntas;
        }

        public void AdicionarPergunta(Pergunta pergunta) {
            Perguntas.Add(pergunta);
        }

        public void Liberar()
        {
            Situacao = ESituacao.Liberado;
        }

        public void VincularGrupoUsuario(GrupoUsuario grupoUsuario)
        {
            GruposUsuarios.Add(grupoUsuario);
        }

        public bool EstaValido() => GruposUsuarios.Any() && Perguntas.Any();
    }
}
