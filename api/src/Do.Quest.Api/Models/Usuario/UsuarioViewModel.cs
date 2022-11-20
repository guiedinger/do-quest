using System.ComponentModel.DataAnnotations;

namespace Do.Quest.Api.Models.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {1} caracteres", MinimumLength = 3)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool IsAdmin { get; set; }

        public Guid? GrupoUsuarioId { get; set; }
    }
}
