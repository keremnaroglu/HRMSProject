using HRMSProject.DAL.Concrete.Repositories.Abstract;
using HRMSProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.DAL.Concrete.Repositories.Concrete
{
    public class UserRepository : Repository<AppUser, HRMSDbContext>, IUserRepository
    {
        public UserRepository(HRMSDbContext db) : base(db)
        {
        }
    }
}
