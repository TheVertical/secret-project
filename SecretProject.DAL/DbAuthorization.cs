using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.DAL
{
    public class DbAuthorization : IDbAuthorization
    {
        public DbAuthorization()
        {

        }

        public AuthorizationResult Result { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
