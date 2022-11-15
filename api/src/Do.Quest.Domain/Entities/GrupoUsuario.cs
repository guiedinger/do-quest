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

        public void AdicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
    }
}
