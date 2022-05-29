using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data
{
    public static class DbInitializer
    {

        public static void Initialize(SqlServerContext context)
        {
            context.Database.EnsureCreated();

        }

    }
}
