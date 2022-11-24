using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Api.Models.Pergunta;
using Do.Quest.Domain.Entities;

namespace Do.Quest.Api.Mappers
{
    public static class PerguntaMapper
    {
        public static List<Pergunta> Map(IEnumerable<PerguntaViewModel> perguntasViewModel)
        {
            if (perguntasViewModel == null)
                return default;

            var grupoUsuario = perguntasViewModel.Select(c => new Pergunta(c.Descricao, MapResposta(c))).ToList();

            return grupoUsuario;
        }

        private static Resposta MapResposta(PerguntaViewModel pergunta)
        {
            switch (pergunta.TipoPergunta)
            {
                case Enuns.ETipo.Objetiva: return new RespostaObjetiva(AlternativaMapper.Map(pergunta.Alternativas));
                default : return default;
            }
        }
    }
}
