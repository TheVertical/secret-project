using System;

namespace SecretProject.BusinessProject.ViewModels.UserData
{
    [Serializable]
    public class RegistrationAccountViewModel
    {
        public RegistrationAccountViewModel()
        {   
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
