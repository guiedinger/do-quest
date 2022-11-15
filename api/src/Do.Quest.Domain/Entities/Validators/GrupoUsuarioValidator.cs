using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.Quest.Domain.Entities.Validators
{
    public class GrupoUsuarioValidator : AbstractValidator<GrupoUsuario>
    {
        public GrupoUsuarioValidator()
        {
            RuleFor(gu => gu.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
