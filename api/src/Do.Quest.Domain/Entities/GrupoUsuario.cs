namespace Do.Quest.Domain.Entities
{
    public class GrupoUsuario : Entity
    {
        public string Descricao { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        public GrupoUsuario(string descricao)
        {
            Descricao = descricao;
            Usuarios = new List<Usuario>();
        }

        public bool AdicionarUsuario(Usuario usuario)
        {
            if (Usuarios.Any(u => u.Id.Equals(usuario.Id)))
                return false;
            
            Usuarios.Add(usuario);
            return true;
        }

        public void RemoverUsuario(Usuario usuario)
        {
            if (Usuarios.Any(u => u.Id.Equals(usuario.Id)))
                Usuarios.Remove(usuario);
        }
    }
}
