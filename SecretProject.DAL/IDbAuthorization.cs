using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.DAL
{
    public interface IDbAuthorization
    {
        AuthorizationResult Result { get; set; }
    }

    public enum AuthorizationResult
    {
        /// <summary>
        /// Пользователь подтвержден и ему разрешен доступ
        /// </summary>
        Confirmed,
        /// <summary>
        /// Пользователю отказано в доступе
        /// </summary>
        Canceled,
        /// <summary>
        /// Пользователь не найден среди списка всех пользователей
        /// </summary>
        NotFound
    }
}
