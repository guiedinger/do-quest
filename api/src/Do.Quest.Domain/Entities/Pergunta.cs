namespace Do.Quest.Domain.Entities
{
    public class Pergunta
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public Resposta Resposta { get; private set; }

        private Pergunta() { }

        public Pergunta(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public Pergunta(string descricao, Resposta resposta)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Resposta = resposta;
        }

        public void Responder(Resposta resposta)
        {
           Resposta = resposta;
        }

        public bool Respondida() => Resposta != null;
    }
}
