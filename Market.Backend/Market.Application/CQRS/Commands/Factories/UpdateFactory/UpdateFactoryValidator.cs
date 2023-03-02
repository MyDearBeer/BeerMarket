using FluentValidation;
using Market.Application.CQRS.Commands.Factories.CreateFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.UpdateFactory
{
    public class UpdateFactoryValidator : AbstractValidator<UpdateFactoryCommand>
    {
        public UpdateFactoryValidator()
        {
            RuleFor(createFactoryCommand =>
            createFactoryCommand.Id).NotEmpty();
            RuleFor(createFactoryCommand =>
            createFactoryCommand.Name).NotEmpty();
            RuleFor(createFactoryCommand =>
           createFactoryCommand.Img).NotEmpty();
        }
    }
   
}
