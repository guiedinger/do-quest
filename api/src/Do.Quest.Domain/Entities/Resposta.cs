using Do.Quest.Domain.Enums;

namespace Do.Quest.Domain.Entities
{
    public abstract class Resposta
    {
        public Guid Id { get; private set; }
        public DateTime Data { get; protected set; }

        protected Resposta()
        {
            Id = Guid.NewGuid();
        }
    }
}
