using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSys.Entity.Base;
using PaymentSys.Entity.IBase;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSys.WebApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ApiBaseController<TService, T, TDto> : ControllerBase where TService : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {   private readonly TService service;
    public ApiBaseController(TService service)
    {
        this.service = service;
    }

    //api/customer/find
    //api/customer/Getir
    [HttpGet("Find")]
    public IResponse<TDto> Find(int id)
    {
        try
        {
            return service.Find(id);
        }
        catch (Exception ex)
        {
            return new Response<TDto>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = $"Error:{ex.Message}",
                Data = null
            };
        }
    }

    [HttpGet("GetAll")]
    public IResponse<List<TDto>> GetAll()
    {
        try
        {
            return service.GetAll();
        }
        catch (Exception ex)
        {
            return new Response<List<TDto>>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = $"Error:{ex.Message}",
                Data = null
            };
        }
    }

    [HttpPost("Add")]
    public IResponse<TDto> Add(TDto entity)
    {
        try
        {
            return service.Add(entity);
        }
        catch (Exception ex)
        {
            return new Response<TDto>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = $"Error:{ex.Message}",
                Data = null
            };
        }
    }
    [HttpDelete("Delete")]
    public IResponse<bool> Delete(int id)
    {
        try
        {
            return service.DeleteByID(id);
        }
        catch (Exception ex)
        {
            return new Response<bool>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = $"Error:{ex.Message}",
                Data = false
            };
        }
    }


    [HttpPut("Update")]
    public IResponse<TDto> Update(TDto entity)
    {
        try
        {
            return service.Update(entity);
        }
        catch (Exception ex)
        {
            return new Response<TDto>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = $"Error:{ex.Message}",
                Data = null
            };
        }
    }
}
}
