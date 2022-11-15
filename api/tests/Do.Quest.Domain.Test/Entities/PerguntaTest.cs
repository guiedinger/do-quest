using Do.Quest.Domain.Entities;
using FluentAssertions;

namespace Do.Quest.Domain.Test.Entities
{
    public class PerguntaTest
    {
        [Fact]
        public void CriarPerguntaComSucesso()
        {
            var pergunta = new Pergunta("Esse teste é válido?");

            pergunta.Respondida().Should().BeFalse();
        }

        [Fact]
        public void CriarPerguntaComRespostaQuePossuiAlternativas()
        {
            var alternativaA = new Alternativa("Primeira Alternativa", "A");
            var alternativaB = new Alternativa("Segunda Alternativa", "B");
            var resposta = new RespostaObjetiva();
            resposta.AdicionarAlernativa(alternativaA);
            resposta.AdicionarAlernativa(alternativaB);

            var pergunta = new Pergunta("Esse teste é válido?", resposta);

            pergunta.Respondida().Should().BeFalse();
        }

        [Fact]
        public void ResponderPerguntaComRespostaObjetiva()
        {
            var alternativaA = new Alternativa("Primeira Alternativa", "A");
            var alternativaB = new Alternativa("Segunda Alternativa", "B");
            var resposta = new RespostaObjetiva();
            resposta.AdicionarAlernativa(alternativaA);
            resposta.AdicionarAlernativa(alternativaB);
            resposta.EscolherAlternativa("A");

            var pergunta = new Pergunta("Esse teste é válido?");
            pergunta.Responder(resposta);

            pergunta.Respondida().Should().BeTrue();
        }

        [Fact]
        public void ResponderPerguntaComRespostaDissertativa()
        {
            var resposta = new RespostaDissertativa("Sim, é o que esperamos!");

            var pergunta = new Pergunta("Esse teste é válido?");
            pergunta.Responder(resposta);

            pergunta.Respondida().Should().BeTrue();
        }

    }
}
