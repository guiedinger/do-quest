﻿using Do.Quest.Domain.Entities;

namespace Do.Quest.Domain.Interfaces.Repositories
{
   public interface IQuestionarioRepository {
      Task CadastrarOuAtualizar(Questionario questionario);
      Task AdicionarUsuarioAsync(Usuario usuario);
      Task AdicionarGrupoUsuariosAsync(GrupoUsuario grupoUsuario);
      Task AdicionarUsuariosAsync(IEnumerable<Usuario> usuarios);
      Task GetQuestionario(GrupoUsuario grupoUsuario);
   }
}
