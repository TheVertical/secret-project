using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Other;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess.Repository;
using SecretProject.Web.Infrastructure.Authentication;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly Guid defaultLanguageId = Constants.LanguageCodeIds["RU"];
        private readonly ILogger<LocalizationService> logger;
        private readonly LocalizationContext context;
        private readonly UserManager<AppUser> userManager;

        public LocalizationService(ILogger<LocalizationService> logger,
            LocalizationContext context,
            UserManager<AppUser> userManager)
        {
            this.logger = logger;
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> LocalizeAsync(LocalizationKey key, CancellationToken cancellationToken)
        {
            try
            {
                await using (IRepository repository = new BaseRepository(logger, context))
                {
                    var localizedString = (await repository.GetAsync<LocalizedString>(item => item.Key == key, cancellationToken)).FirstOrDefault();

                    if (localizedString == null)
                    {
                        return Enum.GetName<LocalizationKey>(key);
                    }

                    return localizedString.Value;
                }
            }
            catch (Exception)
            {
                return Enum.GetName<LocalizationKey>(key);
            }
        }

        public async Task<Guid> GetDefaultLanguageAsync(Guid? userId, CancellationToken cancellationToken)
        {
            if (userId == null)
            {
                return Constants.LanguageCodeIds["RU"];
            }

            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return Constants.LanguageCodeIds["RU"];
            }

            return user.LanguageId;
        }

        public async Task<IDictionary<string, string>> GetLiterals<TEnum>(Guid languageId, CancellationToken cancellationToken) where TEnum : Enum
        {
            try
            {
                ValidateLanguageId(languageId);

                await using (ILocalizationRepository repository = new LocalizationRepository(logger, context))
                {
                    var literals = await repository.GetLiteralsAsync<TEnum>(languageId, cancellationToken);

                    return literals.ToDictionary(l => l.KeyString, l => l.Value);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "In LocalizationService");
                throw;
            }
        }

        private Guid ValidateLanguageId(Guid languageId)
         {
            if (Constants.LanguageCodeIds.ContainsValue(languageId))
            {
                return languageId;
            }

            logger.LogWarning("There was try to get unregistered language!", languageId);

            return defaultLanguageId;
        }
    }
}
