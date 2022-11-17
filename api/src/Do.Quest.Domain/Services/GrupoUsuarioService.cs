﻿using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Entities.Validators;
using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;

namespace Do.Quest.Domain.Services
{
    public class GrupoUsuarioService : BaseService, IGrupoUsuarioService
    {
        private readonly IQuestionarioRepository _questionarioRepository;

        public GrupoUsuarioService(IQuestionarioRepository questionarioRepository, 
                                   INotificador notificador) 
                                   : base (notificador)
        {
            _questionarioRepository = questionarioRepository;
        }

        public async Task<string> AdicionarAsync(GrupoUsuario grupoUsuario)
        {
            if (!EstaValido(grupoUsuario)) 
                return null;

            await _questionarioRepository.AdicionarGrupoUsuariosAsync(grupoUsuario);
            
            return grupoUsuario.Id.ToString();
        }

        private bool EstaValido(GrupoUsuario grupoUsuario)
        {
            return ExecutarValidacao(new GrupoUsuarioValidator(), grupoUsuario);
        }
    }
}
