using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SecretProject.DAL.Contexts.Factories
{
    public class BaseContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : DbContext
    {

        protected virtual string DefaultConnectionString { get; }
        public TDbContext CreateDbContext(string connectionString)
        {
            var arguments = new List<string>
            {
                "--connection " + connectionString
            };

            return CreateDbContext(arguments.ToArray());
        }

        public TDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            var connectionString = args.FirstOrDefault(arg => arg.Contains("--connection "));

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                if (string.IsNullOrWhiteSpace(DefaultConnectionString))
                {
                    throw new Exception($"Missed default connection string for {typeof(TDbContext)} (db context)");
                }

                connectionString = DefaultConnectionString;
            }
            else
            {
                connectionString = connectionString.Remove(0, "--connection ".Length);
            }

            const int failureTries = 3;
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure(failureTries));

            return Activator.CreateInstance(typeof(TDbContext), args: optionsBuilder.Options) as TDbContext;
        }
    }
}
