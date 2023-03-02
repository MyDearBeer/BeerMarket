using FluentValidation;
using Market.Application.CQRS.Commands.Types.UpdateType;
using Market.Application.Products.Commands.DeleteType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Types.DeleteType
{
    public class DeleteTypeValidator : AbstractValidator<DeleteTypeCommand>
    {
        public DeleteTypeValidator()
        {
            RuleFor(deleteTypeCommand =>
            deleteTypeCommand.Id).NotEmpty();
        }
    }
}
