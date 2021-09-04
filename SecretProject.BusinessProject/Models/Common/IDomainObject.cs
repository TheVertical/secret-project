using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace SecretProject.BusinessProject.Models
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
