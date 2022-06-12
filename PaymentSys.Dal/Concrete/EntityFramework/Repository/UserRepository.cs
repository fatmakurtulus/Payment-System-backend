using PaymentSys.Entity.Models;
using PaymentSys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PaymentSys.Dal.Abstract;
using Microsoft.EntityFrameworkCore;

namespace PaymentSys.Dal.Concrete.EntityFramework.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        //public User Login(User login)
        //{
        //    var user = dbset.Where(x => x.Mail == login.Mail && x.Password == login.Password).SingleOrDefault();

        //    //var user = dbset.FirstOrDefault(x => x.Mail == login.Mail && x.Password == login.Password);

        //    //var user = dbset.SingleOrDefault(x => x.Mail == login.Mail && x.Password == login.Password);

        //    return user;
        //}
    }
}
