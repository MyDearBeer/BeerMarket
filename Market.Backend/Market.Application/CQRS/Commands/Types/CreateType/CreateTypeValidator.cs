using FluentValidation;
using Market.Application.CQRS.Commands.Types.UpdateType;
using Market.Application.Products.Commands.CreateType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Types.CreateType
{
    internal class CreateTypeValidator : AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeValidator()
        {
            RuleFor(createTypeCommand =>
            createTypeCommand.Name).NotEmpty();
        }
    }
}
