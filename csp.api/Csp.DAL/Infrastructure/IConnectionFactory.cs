using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Csp.DAL.Infrastructure
{
    public interface IConnectionFactory
    {
        public IDbConnection GetConnection { get; }
    }
}
