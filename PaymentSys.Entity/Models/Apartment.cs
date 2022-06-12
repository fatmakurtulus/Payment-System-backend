using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSys.Entity.Models
{
    public partial class Apartment : EntityBase
    {
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
