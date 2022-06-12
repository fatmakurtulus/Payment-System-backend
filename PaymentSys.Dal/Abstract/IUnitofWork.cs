using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Dal.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        //bll de kullanılacak
        IGenericRepository<T> GetRepository<T>() where T : EntityBase;

        bool BeginTransaction();        //başlattık
        bool RollBackTransaction();//hata durumunda geri aldık

        int SaveChanges(); //Transaction onayladık
    }
}
