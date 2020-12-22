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
    public class ReportDailySalesRepository : GenericRepository<Sale>, IReportDailySalesRepository
    {
        public ReportDailySalesRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {
        }
        
        public async Task<IEnumerable<Sale>> SearchReportDailySalesByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "Sale.Code", bool orderAsc = false)
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

                var searchString = p.Count == 0 ? "1=1" : String.Join(" AND ", p.ToArray());

                var query = String.Format(@"SELECT Sale.ID,Sale.Code,Sale.CreatedAt,Sale.SalePrice,Sale.SalePriceVat,Sale.SalePriceIncludeVat,Contact.ID AS ContactID,Contact.Name
                    FROM Sale
                    INNER JOIN Contact ON Sale.ContactID = Contact.ID
                    WHERE {0} ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;", searchString, orderBy, orderAsc ? "ASC" : "DESC");

                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                var sale = await SqlMapper.QueryAsync<Sale ,Contact, Sale>(connection, query, (sale, contact) =>
                {
                    sale.Contact = contact;
                    return sale;
                }, splitOn: "ContactID"
                 , param: param);

                return (sale);
            }
        }

        public async Task<int> GetTotalSearchReportDailySalesByField(Dictionary<string, string> searchParams)
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

                var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

                var query = @"SELECT COUNT(*)
                    FROM Sale
                    INNER JOIN Contact ON Sale.ContactID = Contact.ID
                            WHERE {0};";

                query = String.Format(query, searchString);
                var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);
                return totalrows;
            }
        }
    }
}
