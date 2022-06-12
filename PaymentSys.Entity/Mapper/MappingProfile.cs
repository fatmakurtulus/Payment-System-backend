using AutoMapper;
using PaymentSys.Entity.Dto;
using PaymentSys.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Entity.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<Apartment, DtoApartment>().ReverseMap();
            CreateMap<Payment, DtoPayment>().ReverseMap();
            CreateMap<PaymentType, DtoPaymentType>().ReverseMap();
            //CreateMap<User, DtoLoginUser>();
            //CreateMap<DtoLogin, User>();


        }
    }
}
