using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Entity.Dto
{
    public class DtoUser :DtoBase
    {
        public DtoUser()
        {
                
        }
      
        public int Tc { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string PlateNumber { get; set; }
        public string Password { get; set; }

    }
}
