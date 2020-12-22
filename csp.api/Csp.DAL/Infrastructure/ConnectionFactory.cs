using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Csp.DAL.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IConfiguration Configuration { get; set; }

        public ConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = Configuration.GetConnectionString("CspDatabase");
                conn.Open();
                return conn;
            }
        }


    }
}
