using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.DAL.Contexts
{
    public class sBaseContextFactory : IDesignTimeDbContextFactory<sBaseContext>
    {
        public sBaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<sBaseContext>();
            var connectionString = @"data source=DESKTOP-P7SS3RO;initial catalog=SecretDb;Integrated security = True;App=EntityFramework";
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            //.ConfigureWarnings(warning => warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new sBaseContext(optionsBuilder.Options);
        }
    }
}
