using PaymentSys.Entity.Base;
using PaymentSys.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Entity.Dto
{
    public class DtoApartment : DtoBase
    {

        public DtoApartment()
        {
                
        }
        public int ApartId { get; set; }
        public int? ApartOwnerTc { get; set; }
        public string ApartType { get; set; }
        public string Apartblock { get; set; }
        public string ApartFloor { get; set; }
        public string ApartNumber { get; set; }
        public bool ApartIsFull { get; set; }

        public virtual User ApartOwnerTcNavigation { get; set; }
    }
}

