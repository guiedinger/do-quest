﻿using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task AdicionarAsync(Usuario user);
        Usuario? Find(Usuario user);
        Task<List<Usuario>> GetUsuarios();

    }
}
