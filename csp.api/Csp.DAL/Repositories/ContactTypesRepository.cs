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
    public class ContactTypesRepository : GenericRepository<Contact>, IContactTypesRepository
    {
        public ContactTypesRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {
        }
        public async Task<IEnumerable<Contact>> SearchVenderbyField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return await SearchContactTypesbyField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }
        public async Task<IEnumerable<Contact>> CheckDuplicateVender(Dictionary<string, string> searchParams)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return await CheckDuplicate(searchParams, connection);
            }
        }
        public async Task<int> GetTotalSearchVenderByField(Dictionary<string, string> searchParams)
        {
            return await GetTotalSearchContactTypesByField(searchParams);
        }

        public async Task<IEnumerable<Contact>> SearchCustomerbyField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return await SearchContactTypesbyField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }

        public async Task<IEnumerable<Contact>> CheckDuplicateCustomer(Dictionary<string, string> searchParams)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return await CheckDuplicate(searchParams, connection);
            }
        }

        

        
        public async Task<int> GetTotalSearchCustomerByField(Dictionary<string, string> searchParams)
        {
            return await GetTotalSearchContactTypesByField(searchParams);
        }

        private async Task<IEnumerable<Contact>> SearchContactTypesbyField(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc)
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

                var query = String.Format(@"SELECT contact.ID, contact.Code, contact.Name, contact.Phone, contact.Moblie1, contact.CustomerType, contact.CreditLimit, contact.Overdue, contact.CusContactName,contact.CreditTerm, contact.Active, prefix.ID AS PrefixID, prefix.Name, province.ID AS ProvinceID, province.Name, contactype.ID AS ContactTypeID, contactype.Name
                    FROM Contact
                    LEFT JOIN MasterPrefix AS prefix ON contact.PrefixID = prefix.ID
                    INNER JOIN MasterProvince AS province ON contact.ProvinceID = province.ID
                    INNER JOIN MasterContactType AS contactype ON contact.ContactTypeID = contactype.ID
                    WHERE {0} ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;", searchString, orderBy, orderAsc ? "ASC" : "DESC");
                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                var contacts = await SqlMapper.QueryAsync<Contact, MasterPrefix, MasterProvince, MasterContactType, Contact>(connection, query, (contact, prefix, province, contacttype) =>
                {
                    contact.Prefix = prefix;
                    contact.Province = province;
                    contact.ContactType = contacttype;
                    return contact;
                }, splitOn: "PrefixID,ProvinceID,ContactTypeID"
                 , param: param);

                return (contacts);
            }
        }

        private static async Task<IEnumerable<Contact>> CheckDuplicate(Dictionary<string, string> searchParams, IDbConnection connection)
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
            var searchString = p.Count == 0 ? "1=1" : String.Join(" OR ", p.ToArray());
            var query = String.Format("SELECT * FROM Contact WHERE {0};", searchString);
            return await SqlMapper.QueryAsync<Contact>(connection, query, commandType: CommandType.Text);
        }

        

        private async Task<int> GetTotalSearchContactTypesByField(Dictionary<string, string> searchParams)
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

                var query = @"SELECT Count(*) 
                    FROM Contact AS contact 
                    INNER JOIN MasterPrefix AS prefix ON contact.PrefixID = prefix.ID
                    INNER JOIN MasterProvince AS province ON contact.ProvinceID = province.ID
                    INNER JOIN MasterContactType AS contactype ON contact.ContactTypeID = contactype.ID
                    WHERE {0};";

                query = String.Format(query, searchString);

                var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);

                return (totalrows);
            }
        }
    }
}
