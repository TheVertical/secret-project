using SecretProject.BusinessProject.Models.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SecretProject.BusinessProject.Models.Order
{
    [Table("Orders.Details")]
    public class OrderDetails : IDomainObject
    {
        #region Model

        #region Base Property

        [Key]
        public virtual Guid Id { get; set; }
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        public string FirstNameCustomer { get; set; }
        public string LastNameCustomer { get; set; }

        public string PhoneNumber { get => MainPhone.PhoneDigits; set => MainPhone.PhoneNumber = value; }
        [NotMapped]
        public Phone MainPhone = new Phone();
        public string AdditionalPhoneNumber { get => AdditionalPhone.PhoneDigits; set => AdditionalPhone.PhoneNumber = value; }
        [NotMapped]
        public Phone AdditionalPhone = new Phone();
        public bool IsWithDelivery { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string District { get; set; }
        public virtual string Street { get; set; }
        public virtual int BuildNumber { get; set; }
        public virtual byte Entrance { get; set; }
        public virtual byte Floor { get; set; }
        public virtual int ApartmentNumber { get; set; }
        public virtual string BuildLiteral { get; set; }
        public virtual int BuildCorps { get; set; }

        #endregion


        #region Foreign keys
        public int? UserId { get; set; }
        #endregion



        #endregion
        #region Class Methods
        #endregion

    }
}
