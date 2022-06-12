using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSys.Entity.Models
{
    public partial class User :EntityBase
    {
        public User()
        {
            Apartments = new HashSet<Apartment>();
            Payments = new HashSet<Payment>();
        }

        public int Tc { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string PlateNumber { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
