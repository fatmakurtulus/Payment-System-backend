using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Entity.Dto
{
    public class DtoPaymentType : DtoBase
    {
        public DtoPaymentType()
        {
           
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

       
    }
}

