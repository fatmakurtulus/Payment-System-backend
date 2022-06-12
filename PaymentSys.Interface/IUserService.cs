using PaymentSys.Entity.Dto;
using PaymentSys.Entity.IBase;
using PaymentSys.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Interface
{
    public interface IUserService : IGenericService<User, DtoUser>
    {

      //  IResponse<DtoUserToken> Login(DtoLogin login);
    }
}
