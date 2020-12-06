using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SecretProject.DAL.Contexts
{
    public class sBaseContextFactory : IDesignTimeDbContextFactory<sBaseContext>
    {
        public sBaseContext CreateDbContext(string connectionString)
        {
            string[] ar = new string[1];
            ar[0] = connectionString;
            return CreateDbContext(ar);
        }
        public sBaseContext CreateDbContext(string[] args)
        {
            //0-ой элемент args - это строка подключения в данном методе
            var optionsBuilder = new DbContextOptionsBuilder<sBaseContext>();
            var connectionString = args[0];
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            //.ConfigureWarnings(warning => warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new sBaseContext(optionsBuilder.Options);
        }
    }
}
