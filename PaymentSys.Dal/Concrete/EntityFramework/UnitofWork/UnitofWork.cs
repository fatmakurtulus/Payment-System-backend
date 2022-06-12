using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PaymentSys.Dal.Abstract;
using PaymentSys.Dal.Concrete.EntityFramework.Repository;
using PaymentSys.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSys.Dal.Concrete.EntityFramework.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {

        DbContext context;
        IDbContextTransaction transaction;
        bool dispose;

        public UnitofWork(DbContext context)
        {
            this.context = context;

        }

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//garbage collecter(çöp toplama)
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            dispose = true;
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();
            using (_transaction)//using hata olsada olmasada transactionı öldürür.
            {//işlemler async ise o sekilde tanımlnır 
                try
                {
                    if (context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }
                    int result = context.SaveChanges();

                    _transaction.Commit();//transaction onaylandığı yer.

                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw new Exception("Error on save changes", ex);
                }
            }
        }
    }
}
