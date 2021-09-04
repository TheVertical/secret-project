using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretProject.DAL.Contexts
{
    public class MainContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        public MainContext CreateDbContext(string connectionString)
        {
            var arguments = new List<string>
            {
                "--connection " + connectionString
            };

            return CreateDbContext(arguments.ToArray());
        }

        public MainContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
            var connectionString = args.FirstOrDefault(arg => arg.Contains("--connection "));

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                connectionString =
                    "server=(local);Initial Catalog='SecretDb_Main';User Id = sa;Password = potapov2222;App=EntityFramework";
            }
            else
            {
                connectionString = connectionString.Remove(0, "--connection ".Length);
            }


            const int failureTries = 3;
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure(failureTries));

            return new MainContext(optionsBuilder.Options);
        }
    }
}
