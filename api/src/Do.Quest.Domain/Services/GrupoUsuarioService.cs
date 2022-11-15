using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Domain.Services
{
    public class GrupoUsuarioService : IGrupoUsuarioService
    {
        private readonly IQuestionarioRepository _questionarioRepository;

        public GrupoUsuarioService(IQuestionarioRepository questionarioRepository)
        {
            _questionarioRepository = questionarioRepository;
        }

        public async Task AdicionarAsync(GrupoUsuario grupoUsuario)
        {
            await _questionarioRepository.AdicionarGrupoUsuarios(grupoUsuario);
        }
    }
}
