using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Repository
{
    public class UserRepostory
    {

        private readonly SqlServerContext _context;

        public UserRepostory(SqlServerContext context)
        {
            _context = context;
        }
    }
}
