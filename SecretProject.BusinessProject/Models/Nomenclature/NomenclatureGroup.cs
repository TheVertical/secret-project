using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SecretProject.BusinessProject.Models.Common;

namespace SecretProject.BusinessProject.Models.Nomenclature
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
