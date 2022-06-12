using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSys.Entity.Dto;
using PaymentSys.Entity.Models;
using PaymentSys.Interface;
using PaymentSys.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSys.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ApiBaseController<IApartmentService,Apartment,DtoApartment>
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService apartmentService): base(apartmentService)
        {
            this.apartmentService = apartmentService;
        }
    }
}
