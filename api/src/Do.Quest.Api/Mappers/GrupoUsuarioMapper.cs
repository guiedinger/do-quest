using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Domain.Entities;

namespace Do.Quest.Api.Mappers
{
    public static class GrupoUsuarioMapper
    {
        public static GrupoUsuario Map(GrupoUsuarioViewModel grupoUsuarioViewModel)
        {
            if (grupoUsuarioViewModel == null)
                return default;

            var grupoUsuario = new GrupoUsuario(grupoUsuarioViewModel.Descricao);

            return grupoUsuario;
        }

        public static IEnumerable<GrupoUsuarioViewModel> Map(IEnumerable<GrupoUsuario> gruposUsuarios)
        {
            if (gruposUsuarios == null)
                return default;

            var grupoUsuarioResponse = gruposUsuarios.Select(gu => new GrupoUsuarioViewModel
            {
                Descricao = gu.Descricao,
                Id = gu.Id
            });

            return grupoUsuarioResponse;
        }
    }
}
