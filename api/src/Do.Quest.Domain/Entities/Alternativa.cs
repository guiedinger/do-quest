namespace Do.Quest.Domain.Entities
{
    public class Alternativa
    {
        public Guid Id { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        private Alternativa() { }

        public Alternativa(string descricao, string codigo)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Codigo = codigo;
        }
    }
}
