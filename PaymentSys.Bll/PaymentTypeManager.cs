
using PaymentSys.Entity.Dto;
using PaymentSys.Entity.IBase;
using PaymentSys.Entity.Models;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PaymentSys.Dal.Abstract;

namespace PaymentSys.Bll
{
    public class PaymentTypeManager : GenericManager<Payment, DtoPaymentType>, IPaymentTypeService
    {
        public readonly IPaymentTypeRepository paymentTypeRepository;

        public PaymentTypeManager(IServiceProvider service) : base(service)
        {
        }

        public IResponse<List<DtoPaymentType>> GetAll(Expression<Func<PaymentType, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
