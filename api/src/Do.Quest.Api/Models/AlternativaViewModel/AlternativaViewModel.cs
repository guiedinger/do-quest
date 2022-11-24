using Do.Quest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Do.Quest.Api.Models.Alternativa {
	public class AlternativaViewModel {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; private set; }

    }
}
