using Do.Quest.Api.Enuns;
using Do.Quest.Api.Models.Alternativa;
using System.ComponentModel.DataAnnotations;

namespace Do.Quest.Api.Models.Pergunta
{
    public class PerguntaViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ETipo TipoPergunta { get; set; }

        public List<AlternativaViewModel> Alternativas { get; set; }

    }
}
