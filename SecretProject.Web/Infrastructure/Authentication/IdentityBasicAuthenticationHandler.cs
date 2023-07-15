using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.Services.Encription;

namespace SecretProject.Web.Infrastructure.Authentication
{
    public class IdentityBasicAuthenticationHandler : IAuthenticationHandler
    {
        private readonly ILogger<IdentityBasicAuthenticationHandler> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserValidator<IdentityUser> userValidator;
        private readonly IUserClaimsPrincipalFactory<IdentityUser> userClaimsPrincipalFactory;
        private HttpContext httpContext;
        private AuthenticationScheme scheme;
        private readonly EncryptionService encryptionService;

        public IdentityBasicAuthenticationHandler(ILogger<IdentityBasicAuthenticationHandler> logger, UserManager<IdentityUser> userManager, IUserValidator<IdentityUser> userValidator, IUserClaimsPrincipalFactory<IdentityUser> userClaimsPrincipalFactory)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.userValidator = userValidator;
            this.userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            this.encryptionService = new EncryptionService();
        }
        public bool AllowMultiple => throw new NotImplementedException();

        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            var request = httpContext.Request;

            if (!request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Unauthorized");

            var authorizationHeader = request.Headers["Authorization"].ToString();

            if (String.IsNullOrEmpty(authorizationHeader))
                return AuthenticateResult.Fail("Unauthorize");

            if(!authorizationHeader.StartsWith("Basic"))
                return AuthenticateResult.Fail("Unauthorize");

            var token = authorizationHeader.Split(' ').LastOrDefault();

            if(String.IsNullOrEmpty(token))
                return AuthenticateResult.Fail("Unauthorize");

            if (rightEnc(token) == false)
                return AuthenticateResult.Fail("Unauthorize");

            //Tuple<string, string> userNameAndPassword = ExtractUserNameAndPassword(token);
            ClaimsPrincipal principal = await AuthenticateAsync("Admin", "potapov2222",CancellationToken.None);
            if (principal == null)
            {
                return AuthenticateResult.Fail("Invalid username or password");
            }

            httpContext.User = principal;
            var ticket = new AuthenticationTicket(principal, "Basic");
            return AuthenticateResult.Success(ticket);
        }

        private async Task<ClaimsPrincipal> AuthenticateAsync(string login, string password, CancellationToken cancellationToken)
        {
            //TODO убрать отсюда соль, и научиться правильно солить пароли!
            var salt = "l12kmlkzspdf";

            //var passwordHash = encryptionService.Encrypt(password + salt);
            var passwordHash = password;
            var user = await userManager.Users
                .Where(u => u.UserName == login && u.PasswordHash == passwordHash).FirstOrDefaultAsync();
            if (user == null)
                return null;

            var result = await userValidator.ValidateAsync(userManager, user);  
            ClaimsPrincipal claimsPrincipal = null;
            if (result.Succeeded)
                claimsPrincipal = await userClaimsPrincipalFactory.CreateAsync(user);
            return claimsPrincipal;
        }

        private bool rightEnc(string token)
        {
            token = token.Trim('=');

            var loggin = "Admin";
            var password = "potapov2222";
            var myToken = loggin + ":" + password;

            var bytes = Encoding.UTF8.GetBytes(myToken);
            myToken = Base64UrlTextEncoder.Encode(bytes);

            return token == myToken;
        }
        private Tuple<string, string> ExtractUserNameAndPassword(string token)
        {
            var tokenBytes = Encoding.UTF8.GetBytes(token);

            var authValue = Convert.ToBase64String(tokenBytes);

            int delimeterPos = authValue.IndexOf(':');
            string login = authValue.Substring(0, delimeterPos);
            string pasw = authValue.Substring(delimeterPos + 1);
            if (String.IsNullOrEmpty(login) && String.IsNullOrEmpty(pasw))
                return null;

            return new Tuple<string, string>(login,pasw);
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            return Task.FromResult(0);
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            if (properties == null)
                properties = new AuthenticationProperties();
                
            properties.RedirectUri = "http://example.com/";
            return Task.FromResult(properties);
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            this.httpContext = context;
            this.scheme = scheme;
            if(scheme.Name == "Basic")
                return Task.CompletedTask;

            return Task.FromResult(0);
        }
    }
}
