using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SecretProject.BusinessProject.ViewModels.UserData;

namespace SecretProject.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateNewAccount(RegistrationAccountViewModel appUserRegistrationViewModel);
    }
}
