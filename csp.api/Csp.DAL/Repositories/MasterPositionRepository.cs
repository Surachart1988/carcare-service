using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public class MasterPositionRepository : GenericRepository<MasterPosition>, IMasterPositionRepository
    {
        public MasterPositionRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {
        }
    }
}
