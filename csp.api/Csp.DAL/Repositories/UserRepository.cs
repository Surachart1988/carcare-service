using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {   
        }

        public async Task<IEnumerable<User>> SrchUsrByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var p = new ArrayList();
                if (searchParams != null)
                {
                    if (searchParams.Count() == 0)
                        throw new Exception();

                    foreach (var searchParam in searchParams)
                    {
                        p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
                    }
                }

                var tmp = this.GetType().Name.Split("Repository");
                var name = String.Format("[{0}]", tmp[0]);

                var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

                var query = @"select e.ID, e.LoginName, e.PositionID, e.Code, e.FirstName, e.LastName, e.Phone, e.Active, e.PositionID, p.Id, p.Name 
                                from [dbo].[User] e 
                                inner join [dbo].[MasterPosition] p on e.PositionID = p.ID
                                WHERE {0}
                                ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                query = String.Format(query, searchString, String.Format("e.{0}", orderBy), orderAsc ? "ASC" : "DESC");

                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                var users = await SqlMapper.QueryAsync<User, MasterPosition, User>(connection, query, (employee, postion) =>
                {
                    employee.Position = postion;
                    return employee;
                }, splitOn: "PositionID"
                 , param: param);

                return users;
            }
        }

        public async Task<int> GetTotalSrchUsrByField(Dictionary<string, string> searchParams)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var p = new ArrayList();
                if (searchParams != null)
                {
                    if (searchParams.Count() == 0)
                        throw new Exception();

                    foreach (var searchParam in searchParams)
                    {
                        p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
                    }
                }

                var tmp = this.GetType().Name.Split("Repository");
                var name = String.Format("[{0}]", tmp[0]);

                var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

                var query = @"select Count(*)
                            from [dbo].[User] e 
                            inner join [dbo].[MasterPosition] p on e.PositionID = p.ID
                            WHERE {0};";

                query = String.Format(query, searchString);
                var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);
                return totalrows;
            }
        }
    }
}
