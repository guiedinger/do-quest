using Do.Quest.Domain.Enums;

namespace Do.Quest.Domain.Entities
{
    public class RespostaDissertativa : Resposta
    {
        public string TextoDissertativo { get; private set; }

        public RespostaDissertativa(string texto)
        {
            Data = DateTime.Now;
            TextoDissertativo = texto;
        }

    }
}
