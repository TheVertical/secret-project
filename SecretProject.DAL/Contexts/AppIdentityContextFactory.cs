using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SecretProject.DAL.Contexts
{
    public class AppIdentityContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            string connectionString = "";
            //TODO Строка находится прямо в коде,потому что запрашивается при использовании команды dotnet ef migrations ...
            if (args == null || args.Length == 0)
                connectionString = "server=DESKTOP-P7SS3RO;Initial Catalog=SecretIdentityDb;User Id = sa;Password = potapov2222;App=EntityFramework";
            else
                connectionString = args[0];
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            //.ConfigureWarnings(warning => warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new AppIdentityDbContext(optionsBuilder.Options);
        }
    }
}