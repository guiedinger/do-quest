using Do.Quest.Domain.Entities;
using FluentAssertions;

namespace Do.Quest.Domain.Test.Entities
{
    public class RespostaTest
    {
        [Fact]
        public void RespostaObjetivaSemQuantidadeMinimaDeAlternativas()
        {
            var alternativaA = new Alternativa("Primeira Alternativa", "A");

            var resposta = new RespostaObjetiva();
            resposta.AdicionarAlernativa(alternativaA);

            resposta.TemNumeroMinimoDeAlternativas().Should().BeFalse();   
        }

        [Fact]
        public void RespostaObjetivaComQuantidadeMinimaDeAlternativas()
        {
            var alternativaA = new Alternativa("Primeira Alternativa", "A");
            var alternativaB = new Alternativa("Segunda Alternativa", "B");
            
            var resposta = new RespostaObjetiva();
            resposta.AdicionarAlernativa(alternativaA);
            resposta.AdicionarAlernativa(alternativaB);

            resposta.TemNumeroMinimoDeAlternativas().Should().BeTrue();
        }
    }
}
