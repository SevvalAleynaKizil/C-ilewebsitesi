using Bussinies.Abstract;
using DataAccsess.Concrete;
using DataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinies.Concrete
{
    public class UsersService : Repository<Users>, IUsersService
    {
        public UsersService(ARContext context) : base(context)
        {

        }
    }
}
