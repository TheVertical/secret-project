using SecretProject.DAL.Contexts.Factories;

namespace SecretProject.DAL.Contexts
{
    public class LocalizationContextFactory : BaseContextFactory<LocalizationContext>
    {
        protected override string DefaultConnectionString => "server=(local);Initial Catalog='SecretDb_Localization';User Id = sa;Password = potapov2222;App=EntityFramework";
    }
}
