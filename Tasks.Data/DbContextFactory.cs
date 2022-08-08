using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tasks.API.Data;

namespace Tasks.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public string ConnectionString { get; set; } = "Server=localhost\\SQLEXPRESS;Database=Tasks;User Id=ADM;Password=zXasqw12@;MultipleActiveResultSets=true";

        public SqlServerContext CreateDbContext(string[] args) =>
            new SqlServerContext(GetDbContextOptionsBuilder<SqlServerContext>());

        public DbContextOptions<TDbContext> GetDbContextOptionsBuilder<TDbContext>() where TDbContext : DbContext =>
            new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer(ConnectionString).Options;
    }
}
