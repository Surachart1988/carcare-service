using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly IConnectionFactory _connectionFactory;
        private int _userId;
        private const string CreatedAt = "CreatedAt";
        private const string UpdatedAt = "UpdatedAt";
        private const string DeletedAt = "DeletedAt";

        private const string CreatedBy = "CreatedBy";
        private const string UpdatedBy = "UpdatedBy";
        private const string DeletedBy = "DeletedBy";


        public GenericRepository(IConnectionFactory connectionFactory, int userId)
        {
            _connectionFactory = connectionFactory;
            _userId = userId;

        }

        public async Task<int> AddRageItems(string sqlcmd, IEnumerable<TEntity> entities)
        {
            int affectedRows;
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    foreach (var item in entities)
                    {
                        if (item.GetType().GetProperty(CreatedAt) != null)
                        {
                            item.GetType().GetProperty(CreatedAt).SetValue(item, DateTime.Now);
                        }
                        if (item.GetType().GetProperty(CreatedBy) != null)
                        {
                            item.GetType().GetProperty(CreatedBy).SetValue(item, _userId);
                        }
                        if (item.GetType().GetProperty(UpdatedAt) != null)
                        {
                            item.GetType().GetProperty(UpdatedAt).SetValue(item, DateTime.Now);
                        }
                        if (item.GetType().GetProperty(UpdatedBy) != null)
                        {
                            item.GetType().GetProperty(UpdatedBy).SetValue(item, _userId);
                        }
                    }

                    //obj = connection.BulkInsert(entities);
                    affectedRows = connection.Execute(sqlcmd, entities);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return affectedRows;
        }

        public async Task<bool> UpdateRageItems(string sqlcmd, IEnumerable<TEntity> entities)
        {
            int affectedRows;
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    foreach (var item in entities)
                    {
                        if (item.GetType().GetProperty(UpdatedAt) != null)
                        {
                            item.GetType().GetProperty(UpdatedAt).SetValue(item, DateTime.Now);
                        }
                        if (item.GetType().GetProperty(UpdatedBy) != null)
                        {
                            item.GetType().GetProperty(UpdatedBy).SetValue(item, _userId);
                        }
                    }

                    //obj = connection.BulkUpdate(entities);
                    affectedRows = connection.Execute(sqlcmd, entities);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return affectedRows > 0;
        }

        public async Task<bool> DeleteRageItems(string sqlcmd, IEnumerable<TEntity> entities)
        {
            int affectedRows;
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    //obj = connection.BulkDelete(entities);
                    affectedRows = connection.Execute(sqlcmd, entities);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return affectedRows > 0;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            long objId = 0;
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    Type t = entity.GetType();
                    foreach (var propInfo in t.GetProperties())
                    {
                        if (propInfo.Name == "CreatedAt")
                        {
                            propInfo.SetValue(entity, DateTime.Now);
                        }

                        if (propInfo.Name == "CreatedBy")
                        {
                            // ToDo store user id
                            propInfo.SetValue(entity, _userId);
                        }

                        if (propInfo.Name == "UpdatedAt")
                        {
                            propInfo.SetValue(entity, DateTime.Now);
                        }

                        if (propInfo.Name == "UpdatedBy")
                        {
                            // ToDo store user id
                            propInfo.SetValue(entity, _userId);
                        }
                    }
                    objId = await connection.InsertAsync<TEntity>(entity);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return await _connectionFactory.GetConnection.GetAsync<TEntity>(objId);

        }

        public async Task<bool> Delete(TEntity entity)
        {
            return await _connectionFactory.GetConnection.DeleteAsync<TEntity>(entity);
        }

        public async Task<TEntity> Get(int Id)
        {
            return await _connectionFactory.GetConnection.GetAsync<TEntity>(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _connectionFactory.GetConnection.GetAllAsync<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> SearchByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
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

                var query = String.Format("SELECT * FROM {0} WHERE {1} ORDER BY {2} {3} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;", name, searchString, orderBy, orderAsc ? "ASC" : "DESC");
                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                return await SqlMapper.QueryAsync<TEntity>(connection, query, param, commandType: CommandType.Text);
           }
        }

        public async Task<int> GetCountSearchByField(Dictionary<string, string> searchParams)
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

                var query = @"SELECT * FROM {0} WHERE {1}";

                query = String.Format(query, name, searchString);
                return  await SqlMapper.QueryFirstAsync<int>(connection, query);
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    Type t = entity.GetType();
                    foreach (var propInfo in t.GetProperties())
                    {
                        if (propInfo.Name == "UpdatedAt")
                        {
                            propInfo.SetValue(entity, DateTime.Now);
                        }

                        if (propInfo.Name == "UpdatedBy")
                        {
                            // ToDo store user id
                            propInfo.SetValue(entity, _userId);
                        }
                    }
                    return await connection.UpdateAsync<TEntity>(entity);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<TEntity>> MasterDataSearchByField(Dictionary<string, string> searchParams, string tableName, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
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

                var query = String.Format(@"SELECT * FROM {0} WHERE {1} ORDER BY {2} {3} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;"
                    , tableName, searchString, orderBy, orderAsc ? "ASC" : "DESC");
                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                return await SqlMapper.QueryAsync<TEntity>(connection, query, param, commandType: CommandType.Text);
            }
        }
        public async Task<int> GetCountMasterDataSearchByField(Dictionary<string, string> searchParams, string tableName)
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

                var query = @"SELECT Count(*) FROM {0} WHERE {1}";

                query = String.Format(query, tableName, searchString);
                return await SqlMapper.QueryFirstAsync<int>(connection, query);
            }
        }
    }
}
