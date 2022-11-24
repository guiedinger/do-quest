using Do.Quest.Domain.Enums;

namespace Do.Quest.Domain.Entities
{
    public class Pergunta : Entity
    {
        public string Descricao { get; private set; }
        public Resposta Resposta { get; private set; }

        private Pergunta() { }

        public Pergunta(string descricao)
        {
            Descricao = descricao;
        }

        public Pergunta(string descricao, Resposta resposta)
        {
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
