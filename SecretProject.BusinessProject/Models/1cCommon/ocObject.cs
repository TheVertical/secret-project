using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class ocObject
    {
        public string ocId { get; set; }
        public int EntityId { get; set; }

        [ForeignKey(nameof(EntityId))]
        public virtual DomainObject DomainObject { get; set; }
    }
}
