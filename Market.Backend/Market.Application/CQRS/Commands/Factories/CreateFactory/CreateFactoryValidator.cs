using FluentValidation;
using Market.Application.CQRS.Commands.Types.UpdateType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.CreateFactory
{
    public class CreateFactoryValidator : AbstractValidator<CreateFactoryCommand>
    {
        public CreateFactoryValidator()
        {
            RuleFor(createFactoryCommand =>
            createFactoryCommand.Name).NotEmpty();
            RuleFor(createFactoryCommand =>
           createFactoryCommand.Img).NotEmpty();
        }
    }
}
