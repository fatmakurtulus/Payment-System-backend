using PaymentSys.Entity.Base;
using PaymentSys.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Entity.Dto
{
    public class DtoPayment : DtoBase
    {
        public DtoPayment()
        {
                
        }
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
