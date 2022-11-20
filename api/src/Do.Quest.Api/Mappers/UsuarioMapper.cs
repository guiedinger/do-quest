using Do.Quest.Api.Models.Usuario;
using Do.Quest.Domain.Entities;

namespace Do.Quest.Api.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario Map(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel == null)
                return default;

            var usuario = new Usuario(usuarioViewModel.Login, 
                                      usuarioViewModel.Senha, 
                                      usuarioViewModel.Nome, 
                                      usuarioViewModel.Sobrenome, 
                                      usuarioViewModel.DataNascimento, 
                                      usuarioViewModel.IsAdmin);

            usuario.AtualizarGrupoUsuario(usuarioViewModel.GrupoUsuarioId, default);

            return usuario;
        }

        public static UsuarioViewModel Map(Usuario usuario)
        {
            if (usuario is null)
                return default;

            var usuarioResponse = new UsuarioViewModel
            {
                Login = usuario.Login,
                Senha = usuario.Senha,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                DataNascimento = usuario.DataNascimento,
                IsAdmin = usuario.IsAdmin,
                GrupoUsuarioId = usuario.GrupoUsuarioId
            };

            return usuarioResponse;
        }

        public static Usuario MapLogin(UsuarioViewLogin usuarioViewLogin)
        {
            if (usuarioViewLogin == null)
                return default;

            return new Usuario(usuarioViewLogin.Login,
                               usuarioViewLogin.Senha);
        }
    }
}
