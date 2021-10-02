using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SecretProject.BusinessProject.ViewModels.UserData;

namespace SecretProject.Web.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ClaimsPrincipal> SignIn(AuthenticationAccountViewModel viewModel,
            CancellationToken cancellationToken);

        Task<IdentityResult> RegisterNew(RegistrationAccountViewModel viewModel,
            CancellationToken cancellationToken);

        Task<Guid> GetDefaultAccountLanguage(Guid? userId, CancellationToken cancellationToken);
        Task SignOut();
    }
}
