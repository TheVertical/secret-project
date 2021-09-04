using System;
using System.Text.Json;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Services.Encription;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.DAL.DataAccess.Repository;
using SecretProject.Web.Infrastructure.Authentication;
using SecretProject.Web.Services;
using SecretProject.WebApi.Services;

namespace SecretProject.WebApi.Infrastructure.Dependecies
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
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApiIdentityContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>,
                AdditionalUserClaimsPrincipalFactory>();

            services.AddIdentityServer(options =>
                {
                    options.UserInteraction = new UserInteractionOptions()
                    {
                        LogoutUrl = "/Identity/account/logout",
                        LoginUrl = "/Identity/account/login",
                        
                        LoginReturnUrlParameter = "returnUrl"
                    };
                })
                .AddApiAuthorization<AppUser, ApiIdentityContext>(options =>
                {
                    options.ApiResources.AddApiResource("MyExternalApi", resource =>
                        resource.WithScopes("a", "b", "c"));
                });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerJwt();
        }

        public void ResolveDependencies(IServiceCollection services)
        {
            services.AddScoped<JsonSerializerOptions>(f => new JsonSerializerOptions() { WriteIndented = true, });
            services.AddScoped<EncriptionService>();
            services.AddScoped<LocalizationService>();
            services.AddTransient<SessionHelper>(SessionHelper.GetHelper);
            services.AddTransient<Cart>(SessionCart.GetCart);
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
