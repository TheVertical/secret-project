using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public interface IDomainObject
    {
        
        #region Base Property
        [Key]
        //UNDONE Задача научиться формировать последовательный guid id
        int Id { get; set; }
        [Timestamp]
        byte[] Timestamp { get; set; }
        #endregion

        #region Special Property
        #endregion

        #region Methods
        /// <summary>
        /// Чужой код формирования guid 
        /// </summary>
        /// <returns></returns>
        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out Guid guid);
        /// <summary>
        /// Чужой код формирования guid
        /// </summary>
        /// TODO Продумать, как правильно формировать последовательный(sequential) guid id на сервер
        public static Guid SequentialGuid()
        {
            const int RPC_S_OK = 0;
            Guid g;
            if (UuidCreateSequential(out g) != RPC_S_OK)
                return Guid.NewGuid();
            else
                return g;
        }
        #endregion
    }
}
