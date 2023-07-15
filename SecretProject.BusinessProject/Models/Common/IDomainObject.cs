using System;
using System.ComponentModel.DataAnnotations;

namespace SecretProject.BusinessProject.Models.Common
{
    public interface IDomainObject
    {
        
        [Key]
        //UNDONE Задача научиться формировать последовательный guid id
        Guid Id { get; set; }
        [Timestamp]
        byte[] Timestamp { get; set; }
    }
}
