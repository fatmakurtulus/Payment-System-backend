using PaymentSys.Dal.Abstract;
using PaymentSys.Entity.Dto;
using PaymentSys.Entity.Models;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentSys.Bll
{
    public class ApartmentManager : GenericManager<Apartment, DtoApartment>, IApartmentService
    {
        public readonly IApartmentRepository apartmentRepository;
        public ApartmentManager(IServiceProvider service) : base(service)
        {
        }
    }
}
