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
using Microsoft.IdentityModel.Tokens;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Services.Encription;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.Services;
using SecretProject.VisualElements;
using SecretProject.Web.Infrastructure.Authentication;
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
        public void ResolveIdentity(IServiceCollection services)
        {
            services.AddDbContext<ApiIdentityContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SecretDb.Identity"));
            });

            services.AddDefaultIdentity<AppUser>()
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
            //services.AddScoped<IdentityBasicAuthenticationHandler>();
            services.AddScoped<JsonSerializerOptions>(f => new JsonSerializerOptions() { WriteIndented = true, });
            services.AddScoped<IVisualRedactor, VisualRedactor>();
            services.AddScoped<EncriptionService>();
            services.AddScoped<IRepository, SqlRepository>();
            services.AddTransient<SessionHelper>(sp => SessionHelper.GetHelper(sp));
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
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
