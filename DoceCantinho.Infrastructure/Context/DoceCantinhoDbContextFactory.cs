using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;

namespace DoceCantinho.Infrastructure.Context
{
    public class DoceCantinhoDbContextFactory
        : IDesignTimeDbContextFactory<DoceCantinhoDbContext>
    {
        public DoceCantinhoDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..",
                "DoceCantinho.API");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(
                    "appsettings.json",
                    optional: false)
                .AddJsonFile(
                    "appsettings.Development.json",
                    optional: true)
                .Build();

            var connectionString =
                configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "A connection string 'DefaultConnection' não foi encontrada.");
            }

            var optionsBuilder =
                new DbContextOptionsBuilder<DoceCantinhoDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new DoceCantinhoDbContext(optionsBuilder.Options);
        }
    }
}