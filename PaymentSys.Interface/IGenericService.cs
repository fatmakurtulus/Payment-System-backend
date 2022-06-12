using PaymentSys.Entity.Base;
using PaymentSys.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Interface
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        //listeleme
        IResponse<List<TDto>> GetAll();
        //filtreli listeleme
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        //getirme 
        IResponse<TDto> Find(int id);
        //kaydetme
        IResponse<TDto> Add(TDto item, bool saveChanges = true);
        //Async kaydetme
        Task<IResponse<TDto>> AddSync(TDto item, bool saveChanges = true);
        //Güncellmeme
        IResponse<TDto> Update(TDto item, bool saveChanges = true);
        //Async Güncelleme
        Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true);
        //Silme
        IResponse<bool> DeleteByID(int id, bool saveChanges = true);
        //async silme
        Task<IResponse<bool>> DeleteByIDAsync(int id, bool saveChanges = true);
        //iqueryable listeleme
        IResponse<IQueryable<TDto>> GetQueryable();

        void Save();
    }
}


