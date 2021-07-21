using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Services.Encription;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.Services;
using SecretProject.VisualElements;
using SecretProject.WebApi.Infrastructure.Authetication;
using SecretProject.WebApi.Services;

namespace SecretProject.WebApi.Infrastructure.Dependecies
{
    public class DependencyResolver
    {
        public void ResolveDependencies(IServiceCollection services)
        {
            services.AddScoped<IdentityBasicAuthenticationHandler>();
            services.AddScoped<JsonSerializerOptions>(f => new JsonSerializerOptions() { WriteIndented = true, });
            services.AddScoped<IVisualRedactor, VisualRedactor>();
            services.AddScoped<EncriptionService>();
            services.AddScoped<IRepository, SqlRepository>();
            services.AddTransient<SessionHelper>(sp => SessionHelper.GetHelper(sp));
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
