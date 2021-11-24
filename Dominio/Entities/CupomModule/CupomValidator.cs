using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.CupomModule;
using FluentValidation;

namespace Dominio.Entities.CupomModule
{
    public class CupomValidator : AbstractValidator<Cupom>
    {
        public CupomValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().NotNull().WithMessage("O campo Nome não pode ser vazio!!!\n");

            RuleFor(x => x.ValorMinimo)
                .NotNull().WithMessage("O campo Valor Mínimo não pode ser nulo!!!\n");



        }





    }
}
