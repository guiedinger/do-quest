using Do.Quest.Api.Models.Alternativa;
using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Domain.Entities;

namespace Do.Quest.Api.Mappers
{
    public static class AlternativaMapper
    {
        public static List<Alternativa> Map(IEnumerable<AlternativaViewModel> alternativaViewModel)
        {
            if (alternativaViewModel == null)
                return default;

            var alternativa = alternativaViewModel.Select(c => new Alternativa(c.Descricao, c.Codigo)).ToList();

            return alternativa;
        }
    }
}
