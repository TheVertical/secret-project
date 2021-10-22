using SecretProject.BusinessProject.Models.Good;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class NomenclatureGroup : IDomainObject
    {
        [Key]
        
        public virtual Guid Id { get; set; }

        [Timestamp]
        public virtual byte[] Timestamp { get; set; }

        public virtual string Name { get; set; }

        public virtual NomenclatureGroup Parent { get; set; }
        
        public virtual IList<NomenclatureGroup> Childs { get; set; }
        
        public VisibleStatus Status { get; set; }
    }
}
