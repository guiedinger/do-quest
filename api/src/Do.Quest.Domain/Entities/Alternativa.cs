namespace Do.Quest.Domain.Entities
{
    public class Alternativa : Entity
    {
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        private Alternativa() { }

        public Alternativa(string descricao, string codigo)
        {
            Descricao = descricao;
            Codigo = codigo;
        }
    }
}
