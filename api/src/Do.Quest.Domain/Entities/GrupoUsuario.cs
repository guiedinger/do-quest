using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Domain.Entities
{
    public class GrupoUsuario
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public IEnumerable<Usuario> Usuarios { get; private set; }

        public GrupoUsuario(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Usuarios = new List<Usuario>();
        }
    }
}
