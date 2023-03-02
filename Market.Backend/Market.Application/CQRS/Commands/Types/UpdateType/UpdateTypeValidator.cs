using FluentValidation;
using Market.Application.Products.Commands.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Types.UpdateType
{
    public class UpdateTypeValidator : AbstractValidator<UpdateTypeCommand>
    {
        public UpdateTypeValidator()
        {
            RuleFor(updateTypeCommand =>
            updateTypeCommand.Id).NotEmpty();
        }
    }
}
