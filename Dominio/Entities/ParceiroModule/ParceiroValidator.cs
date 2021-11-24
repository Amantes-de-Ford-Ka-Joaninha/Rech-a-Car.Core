using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ParceiroModule;
using FluentValidation;

namespace Dominio.Entities.ParceiroModule
{
    public class ParceiroValidator : AbstractValidator<Parceiro>
    {
        public ParceiroValidator()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().NotNull().WithMessage("O Nome do Parceiro não pode ser vazio\n");
        }
    }
}
