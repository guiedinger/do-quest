namespace Do.Quest.Domain.Entities
{
    public class GrupoUsuario
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        public GrupoUsuario(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Usuarios = new List<Usuario>();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
    }
}
