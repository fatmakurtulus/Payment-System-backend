using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSys.Entity.Models
{
    public partial class PaymentType : EntityBase
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
