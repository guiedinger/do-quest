using Do.Quest.Domain.Enums;

namespace Do.Quest.Domain.Entities
{
    public class RespostaObjetiva : Resposta
    {
        public Guid Id { get; private set; }
        public ETipo Tipo { get; private set; }
        public List<Alternativa> Alternativas { get; private set; }
        public Alternativa AlternativaSelecionada { get; private set; }

        public RespostaObjetiva()
        {
            Id = Guid.NewGuid();
            Alternativas = new List<Alternativa>();
            Tipo = ETipo.Objetiva;
        }

        public RespostaObjetiva(List<Alternativa> alternativas)
        {
            Id = Guid.NewGuid();
            Alternativas = alternativas;
            Tipo = ETipo.Objetiva;
        }

        public void EscolherAlternativa(string codigo)
        {
            Data = DateTime.Now;
            AlternativaSelecionada = Alternativas.Find(a => a.Codigo == codigo);
        }

        public void AdicionarAlernativa(Alternativa alternativa)
        {
            Alternativas.Add(alternativa);
        }

        public bool AlternativaEstaSelecionada() => AlternativaSelecionada != null;

        public bool TemNumeroMinimoDeAlternativas() => Alternativas.Count >= 2;
    }
}
