using Do.Quest.Api.Enuns;
using Do.Quest.Api.Models.GrupoUsuario;
using Do.Quest.Api.Models.Pergunta;
using System.ComponentModel.DataAnnotations;

namespace Do.Quest.Api.Models.Questionario {
	public class QuestionarioViewModel {

      [Required(ErrorMessage = "O campo {0} é obrigatório")]
      public string Descricao { get; set; }

      [Required(ErrorMessage = "O campo {0} é obrigatório")]
      public DateTime DataInicio { get; set; }

      [Required(ErrorMessage = "O campo {0} é obrigatório")]
      public DateTime DataFim { get; set; }

      [Required(ErrorMessage = "O campo {0} é obrigatório")]
      public ESituacao Situacao { get; set; }

      [Required(ErrorMessage = "O campo {0} é obrigatório")]
      public IEnumerable<GrupoUsuarioViewModel> GruposUsuarios { get; set; }
      
      [Required(ErrorMessage = "O campo {0} é obrigatório")]
      public IEnumerable<PerguntaViewModel> Perguntas { get; set; }

    }
}
