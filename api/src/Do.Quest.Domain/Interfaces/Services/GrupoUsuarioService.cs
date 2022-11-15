using Do.Quest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Domain.Interfaces.Services
{
    public interface IGrupoUsuarioService
    {
        Task AdicionarAsync(GrupoUsuario grupoUsuario);
    }
}
