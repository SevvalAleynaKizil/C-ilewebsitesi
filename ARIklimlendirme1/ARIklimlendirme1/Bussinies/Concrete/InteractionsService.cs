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
    public class InteractionsService : Repository<Interactions>, IInteractionsService
    {
        public InteractionsService(ARContext context) : base(context)
        {

        }
    }
}
