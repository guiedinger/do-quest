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
            foreach (var usuario in grupoUsuarioViewModel.Usuarios)
            {
                grupoUsuario.AdicionarUsuario(UsuarioMapper.Map(usuario));
            }

            return grupoUsuario;
        }
    }
}
