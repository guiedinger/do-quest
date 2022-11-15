using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Enums;
using FluentAssertions;

namespace Do.Quest.Domain.Test.Entities
{
    public class QuestionarioTest
    {
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public List<GrupoUsuario> GrupoUsuarios { get; private set; }
        public List<Pergunta> Perguntas { get; private set; }

        public QuestionarioTest()
        {
            DataInicio = new DateTime(2022, 11, 15, 12, 00, 00);
            DataFim = new DateTime(2022, 11, 16, 12, 00, 00);
            GrupoUsuarios = new List<GrupoUsuario>();
            Perguntas = new List<Pergunta>();
        }

        [Fact]
        public void CriarQuestionarioValidoComSucesso()
        {
            var grupoUsuario = new GrupoUsuario("Grupo de Usuários Teste");
            var pergunta = new Pergunta("Esse questionário está válido?");

            var questionario = new Questionario("Questionario de Teste", DataInicio, DataFim);
            questionario.VincularGrupoUsuario(grupoUsuario);
            questionario.AdicionarPergunta(pergunta);

            questionario.EstaValido().Should().BeTrue();
        }

        [Fact]
        public void CriarQuestionarioInvalidoComSucesso()
        {
            var questionario = new Questionario("Questionario de Teste", DataInicio, DataFim);

            questionario.EstaValido().Should().BeFalse();
        }

        [Fact]
        public void LiberarQuestionarioParaResposta()
        {
            var grupoUsuario = new GrupoUsuario("Grupo de Usuários Teste");
            var pergunta = new Pergunta("Esse questionário está válido?");

            var questionario = new Questionario("Questionario de Teste", DataInicio, DataFim);
            questionario.VincularGrupoUsuario(grupoUsuario);
            questionario.AdicionarPergunta(pergunta);
            questionario.Liberar();

            questionario.EstaValido().Should().BeTrue();
            questionario.Situacao.Should().Be(ESituacao.Liberado);
        }
    }
}