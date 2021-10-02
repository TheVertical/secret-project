using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecretProject.BusinessProject.Services.Encription;
using SecretProject.DAL.Contexts;
using SecretProject.Web.Infrastructure.Authentication;
using SecretProject.Web.Services;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Infrastructure.Dependecies
{
    public class DependencyResolver
    {
        private IConfiguration Configuration { get; }

        public DependencyResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ResolveContexts(IServiceCollection services)
        {
            services.AddScoped<DbContext, MainContext>(factory => new MainContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDb.Main")));

            services.AddDbContext<ApiIdentityContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SecretDb.Identity"));
            });

            services.AddScoped<LocalizationContext>(factory =>
            {
                var s = new LocalizationContextFactory().CreateDbContext(
                    Configuration.GetConnectionString("SecretDb.Localization"));
                    return s;
                });
        }

        public void ResolveIdentity(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

                // Lockout options.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // User options.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // Password options
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddSignInManager()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApiIdentityContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => Configuration.Bind("JwtBearerOptions", options));

            services.AddScoped<IAccountService, AccountService>();
        }

        public void ResolveCommon(IServiceCollection services)
        {
            services.AddScoped<EncryptionService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void ResolveSpaServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "ClientApp";
            });

            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "ClientApp";
            });
        }
    }
}
