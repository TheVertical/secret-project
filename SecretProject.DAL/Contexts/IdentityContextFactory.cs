using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
                throw new ArgumentException("Connection string is not attended!");
            }

            connectionString = connectionString.Remove(0, "--connectionString ".Length);

            const int failureTries = 3;
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure(failureTries));

            //return new ApiIdentityContext(optionsBuilder.Options);
            return null;
        }
    }
}