using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSys.Entity.Models
{
    public partial class Payment : EntityBase
    {
        public int PaymentId { get; set; }
        public int PaymentOwnerTc { get; set; }
        public int PaymentType { get; set; }
        public string PaymentTotal { get; set; }
        public bool PaymentIsPaid { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual User PaymentOwnerTcNavigation { get; set; }
        public virtual PaymentType PaymentTypeNavigation { get; set; }
    }
}
