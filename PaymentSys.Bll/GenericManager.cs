using Microsoft.AspNetCore.Http;
using PaymentSys.Dal.Abstract;
using PaymentSys.Entity.Base;
using PaymentSys.Entity.IBase;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentSys.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {

        //UnitOfWork
        //IServiceProvider
        //GenericRepository
        //construtor

        private readonly IUnitofWork unitofWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;


        public GenericManager(IServiceProvider service)
        {
            this.service = service;
            unitofWork = service.GetService<IUnitofWork>();
            repository = unitofWork.GetRepository<T>();
        }

        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto tipi model(T) tipine dönüştürülüyor.
                //sebeb: dal t ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);

                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=>$"-{x.Name}:{x.GetValue(model)??""}-"));
                var result = repository.Add(model);
                if (saveChanges)
                    Save();//kaydetme işlemi olduğundan transaction commitlenir

                //Dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
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

        public async Task<IResponse<TDto>> AddSync(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto tipi model(T) tipine dönüştürülüyor.
                //sebeb: dal t ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);

                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=>$"-{x.Name}:{x.GetValue(model)??""}-"));
                var result = await repository.AddAsync(model);

                if (saveChanges)
                    Save();//kaydetme işlemi olduğundan transaction commitlenir

                //Dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
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

        public IResponse<bool> DeleteByID(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);
                if (saveChanges)
                    Save();

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = true
                };
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

        public Task<IResponse<bool>> DeleteByIDAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id));

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = entity
                };
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

        public IResponse<List<TDto>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = listDto
                };
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

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                var list = repository.GetAll();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = listDto
                };
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

        public IResponse<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));

                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public void Save()
        {
            unitofWork.SaveChanges();
        }

        public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto tipi model(T) tipine dönüştürülüyor.
                //sebeb: dal t ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);

                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=>$"-{x.Name}:{x.GetValue(model)??""}-"));
                var result = repository.Update(model);
                if (saveChanges)
                    Save();//kaydetme işlemi olduğundan transaction commitlenir

                //Dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succes",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
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

        public Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
