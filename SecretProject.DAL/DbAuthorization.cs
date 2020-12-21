using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.DAL
{
    public class DbAuthorization : IDbAuthorization
    {
        #region Realization

        public DbAuthorization()
        {

        }
        #endregion

        #region Interface's Methods

        public AuthorizationResult Result { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

    }
}
