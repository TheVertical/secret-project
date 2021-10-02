using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SecretProject.DAL.Contexts
{
    public class ApiIdentityContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public ApiIdentityContext(DbContextOptions<ApiIdentityContext> dbOptions, IOptions<OperationalStoreOptions> options) : base(dbOptions, options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Context is not configured!");
            }
        }
    }
}
