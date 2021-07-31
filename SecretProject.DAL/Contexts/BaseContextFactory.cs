using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SecretProject.DAL.Contexts
{
    public class sBaseContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        public MainContext CreateDbContext(string connectionString)
        {
            string[] ar = new string[1];
            ar[0] = connectionString;
            return CreateDbContext(ar);
        }
        public MainContext CreateDbContext(string[] args)
        {
            //0-ой элемент args - это строка подключения в данном методе
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
            string connectionString = "";
            //TODO Строка находится прямо в коде,потому что запрашивается при использовании команды dotnet ef migrations ...
            //Подумать, как это испоавить
            if (args == null || args.Length == 0)
                connectionString = "server=DESKTOP-P7SS3RO;database=SecretDb;Integrated Security=True;App=EntityFramework";
            else
                connectionString = args[0];
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            //.ConfigureWarnings(warning => warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new MainContext(optionsBuilder.Options);
        }
    }
}
