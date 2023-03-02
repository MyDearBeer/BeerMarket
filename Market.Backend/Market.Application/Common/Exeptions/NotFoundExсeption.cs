using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Common.Exeptions
{
    public class NotFoundExсeption:Exception
    {
        public NotFoundExсeption(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
