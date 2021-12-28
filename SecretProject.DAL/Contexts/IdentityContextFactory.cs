using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SecretProject.DAL.Options;

namespace SecretProject.DAL.Contexts
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<ApiIdentityContext>
    {
        public ApiIdentityContext CreateDbContext(string connectionString)
        {
            var arguments = new List<string>
            {
                "--connectionString " + connectionString
            };

            return CreateDbContext(arguments.ToArray());
        }

        public ApiIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiIdentityContext>();
            var connectionString = args.FirstOrDefault(arg => arg.Contains("--connectionString "));

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                connectionString =
                    "server=(local);Initial Catalog='SecretDb_Identity';User Id = sa;Password = potapov2222;App=EntityFramework";
            }
            else
            {
                connectionString = connectionString.Remove(0, "--connection ".Length);
            }

            connectionString = connectionString.Remove(0, "--connectionString ".Length);

            const int failureTries = 3;
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure(failureTries));

            return new ApiIdentityContext(optionsBuilder.Options, new OperationalStoreOptionsMigrations());
        }
    }
}