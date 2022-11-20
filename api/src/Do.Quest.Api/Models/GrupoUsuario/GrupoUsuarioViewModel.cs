using Do.Quest.Api.Models.Usuario;
using System.ComponentModel.DataAnnotations;

namespace Do.Quest.Api.Models.GrupoUsuario
{
    public class GrupoUsuarioViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
    }
}
