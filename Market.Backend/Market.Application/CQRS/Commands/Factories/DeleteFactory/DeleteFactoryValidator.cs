using FluentValidation;
using Market.Application.CQRS.Commands.Factories.CreateFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.DeleteFactory
{
    public class DeleteFactoryValidator : AbstractValidator<DeleteFactoryCommand>
    {
        public DeleteFactoryValidator()
        {
            RuleFor(deleteFactoryCommand =>
            deleteFactoryCommand.Id).NotEmpty();
           
        }
    }
}
