using System.ComponentModel.DataAnnotations;

namespace Do.Quest.Api.Models.Usuario
{
    public class UsuarioViewLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {1} caracteres", MinimumLength = 3)]
        public string Senha { get; set; }

    }
}
