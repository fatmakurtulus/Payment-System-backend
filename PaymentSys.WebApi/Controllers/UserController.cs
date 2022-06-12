using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSys.Entity.Base;
using PaymentSys.Entity.Dto;
using PaymentSys.Entity.IBase;
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

    public class UserController : ApiBaseController<IUserService, User, DtoUser>
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) : base(userService)
        {
            this.userService = userService;
        }
    }
    //public class UserController : ControllerBase
    //{
    //    private readonly IUserService userService;
    //    public UserController(IUserService userService)
    //    {
    //        this.userService = userService;
    //    }

    //    [HttpPost("Login")]
    //    [AllowAnonymous]
    //    public IResponse<DtoUserToken> Login(DtoLogin login)
    //    {
    //        try
    //        {
    //            return userService.Login(login);
    //        }
    //        catch (Exception ex)
    //        {
    //            return new Response<DtoUserToken>
    //            {
    //                Message = "Error:" + ex.Message,
    //                StatusCode = StatusCodes.Status500InternalServerError,
    //                Data = null
    //            };
    //        }
    //    }
    //}
}
