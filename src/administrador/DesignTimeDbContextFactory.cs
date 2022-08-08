using administrador.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace administrador
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RCVDbContext>
    {
        public RCVDbContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<RCVDbContext>();
            var connectionString = "Server=PostgreSQL 14;Host=localhost;Database=baseDatosAdmin;Username=postgres;password=admin;";
            builder.UseNpgsql(connectionString);
            return new RCVDbContext(builder.Options);
        }
    }
}