using Microsoft.EntityFrameworkCore;
using PaymentSys.Dal.Abstract;
using PaymentSys.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Dal.Concrete.EntityFramework.Repository
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
