using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PaymentSys.Dal.Abstract;
using PaymentSys.Entity.Base;
using PaymentSys.Entity.Dto;
using PaymentSys.Entity.IBase;
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
    public class UserManager : GenericManager<User, DtoUser>, IUserService
    {
        public readonly IUserRepository userRepository;
        //private IConfiguration configuration;

        public UserManager(IServiceProvider service /*,IConfiguration configuration*/) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
           // this.configuration = configuration;
        }

        //public IResponse<DtoUserToken> Login(DtoLogin login)
        //{
        //    var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(login));

        //    if (user != null)
        //    {
        //        var dtoUser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);

        //        var token = new TokenManager(configuration).CreateAccessToken(dtoUser);

        //        var userToken = new DtoUserToken()
        //        {
        //            DtoLoginUser = dtoUser,
        //            AccessToken = token
        //        };

        //        return new Response<DtoUserToken>
        //        {
        //            Message = "Token üretildi.",
        //            StatusCode = StatusCodes.Status200OK,
        //            Data = userToken
        //        };
        //    }
        //    else
        //    {
        //        return new Response<DtoUserToken>
        //        {
        //            Message = "mail veya parolanız yanlış!",
        //            StatusCode = StatusCodes.Status406NotAcceptable,
        //            Data = null
        //        };
        //    }
        //}
    }
}
