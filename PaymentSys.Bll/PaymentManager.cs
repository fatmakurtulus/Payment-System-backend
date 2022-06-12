using PaymentSys.Entity.Dto;
using PaymentSys.Entity.Models;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PaymentSys.Dal.Abstract;

namespace PaymentSys.Bll
{
    public class PaymentManager : GenericManager<Payment,DtoPayment>,IPaymentService
    {
       public readonly IPaymentRepository paymentRepository;

        public PaymentManager(IServiceProvider service) : base(service)
        {
            paymentRepository = service.GetService<IPaymentRepository>();

        }
    }
}
