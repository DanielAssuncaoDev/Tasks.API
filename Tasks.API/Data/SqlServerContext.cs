using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;

namespace Tasks.API.Data
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
                : base(options) { }

        public DbSet<Tb_usuario> Tb_usuario { get; set; }

    }
}
