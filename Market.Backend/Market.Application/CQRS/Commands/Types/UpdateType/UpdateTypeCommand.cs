using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Types.UpdateType
{
    public class UpdateTypeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
