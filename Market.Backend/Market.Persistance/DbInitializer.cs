using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(MarketDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
