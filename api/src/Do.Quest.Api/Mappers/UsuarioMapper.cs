﻿using Do.Quest.Api.Models.Usuario;
using Do.Quest.Domain.Entities;

namespace Do.Quest.Api.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario Map(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel == null)
                return default;

            return new Usuario(usuarioViewModel.Login, 
                               usuarioViewModel.Senha, 
                               usuarioViewModel.Nome, 
                               usuarioViewModel.Sobrenome, 
                               usuarioViewModel.DataNascimento);
        }
    }
}