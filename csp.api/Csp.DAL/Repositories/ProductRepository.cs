using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {
        }

        public async Task<Product> Create(Product product)
        {
            var productResult = await Add(product);

            return productResult;
        }

        public async Task<int> GetTotalSrchProductByField(Dictionary<string, string> searchParams)
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

                var query = @"SELECT 
                                Count(1)
                                FROM Product AS product INNER JOIN
                                                  MasterProType AS protype ON product.ProTypeID = protype.ID 
				                                  LEFT JOIN
                                                  MasterProBrand proband ON product.ProBrandID = proband.ID --AND dbo.MasterProType.ID = dbo.MasterProBrand.ProTypeID 
				                                  LEFT JOIN
                                                  MasterPromodel promodel ON product.ProModelID = promodel.ID --AND dbo.MasterProBrand.ID = dbo.MasterPromodel.ProBrandID 
				                                  LEFT JOIN
                                                  MasterProSize prosize ON product.ProSizeID = prosize.ID
                                WHERE {0}";

                query = String.Format(query, searchString);
                var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);
                return totalrows;
            }
        }
        public async Task<IEnumerable<Product>> SearchProductByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
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

                var query = @"SELECT 
                                product.ID,
                                product.Code, 
                                Product.NameTH,
                                product.CostPrice,
                                protype.ID AS protypeID,
                                protype.Name, 
                                proband.ID AS probandID,
                                proband.Name, 
                                promodel.ID promodelID,
                                promodel.Name, 
                                prosize.ID prosizeID,
                                prosize.Name
                                FROM Product AS product INNER JOIN
                                                  MasterProType AS protype ON product.ProTypeID = protype.ID 
				                                  LEFT JOIN
                                                  MasterProBrand proband ON product.ProBrandID = proband.ID --AND dbo.MasterProType.ID = dbo.MasterProBrand.ProTypeID 
				                                  LEFT JOIN
                                                  MasterPromodel promodel ON product.ProModelID = promodel.ID --AND dbo.MasterProBrand.ID = dbo.MasterPromodel.ProBrandID 
				                                  LEFT JOIN
                                                  MasterProSize prosize ON product.ProSizeID = prosize.ID
                                WHERE {0}
                                ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                query = String.Format(query, searchString, String.Format("Product.{0}", orderBy), orderAsc ? "ASC" : "DESC");

                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                var products = await SqlMapper.QueryAsync<Product, MasterProType, MasterProBrand, MasterPromodel, MasterProSize, Product>(connection, query,
                    (product, protype, probrand, promodel, prosize) =>
                        {
                            product.ProType = protype;
                            product.ProBrand = probrand;
                            product.ProModel = promodel;
                            product.ProSize = prosize;
                            return product;
                        }, splitOn: "protypeID, probandID, promodelID, prosizeID"
                         , param: param);


                return (products);
            }
        }


        // Mystery code 
        //public async Task<(IEnumerable<object> Resources, int TotalRecords)> SearchProductSalePriceByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        //{
        //    using (var connection = _connectionFactory.GetConnection)
        //    {
        //        var p = new ArrayList();
        //        if (searchParams != null)
        //        {
        //            if (searchParams.Count() == 0)
        //                throw new Exception();

        //            foreach (var searchParam in searchParams)
        //            {
        //                p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
        //            }
        //        }

        //        var tmp = this.GetType().Name.Split("Repository");
        //        var name = String.Format("[{0}]", tmp[0]);

        //        var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

        //        var query = @"select e.ID, e.LoginName, e.PositionID, e.Code, e.FirstName, e.LastName, e.Phone, e.Active, e.PositionID, p.Id, p.Name 
        //                        from [dbo].[User] e 
        //                        inner join [dbo].[MasterPosition] p on e.PositionID = p.ID
        //                        WHERE {0}
        //                        ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

        //        query = String.Format(query, searchString, String.Format("e.{0}", orderBy), orderAsc ? "ASC" : "DESC");

        //        var param = new DynamicParameters();
        //        param.Add("@Offset", (pageIndex - 1) * pageSize);
        //        param.Add("@PageSize", pageSize);

        //        var users = await SqlMapper.QueryAsync<User, MasterPosition, User>(connection, query, (employee, postion) =>
        //        {
        //            employee.Position = postion;
        //            return employee;
        //        }, splitOn: "PositionID"
        //         , param: param);

        //        query = @"select Count(*)
        //                        from [dbo].[User] e 
        //                        inner join [dbo].[MasterPosition] p on e.PositionID = p.ID
        //                        WHERE {0};";

        //        query = String.Format(query, searchString);

        //        var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);
        //        var results = users;

        //        return (results, totalrows);
        //    }
        //}
        //public async Task<(IEnumerable<object> Resources, int TotalRecords)> SearchProductForSaleProcessByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        //{
        //    using (var connection = _connectionFactory.GetConnection)
        //    {
        //        var p = new ArrayList();
        //        if (searchParams != null)
        //        {
        //            if (searchParams.Count() == 0)
        //                throw new Exception();

        //            foreach (var searchParam in searchParams)
        //            {
        //                p.Add(string.Format("{0} = '{1}'", searchParam.Key, searchParam.Value));
        //            }
        //        }

        //        var tmp = this.GetType().Name.Split("Repository");
        //        var name = String.Format("[{0}]", tmp[0]);

        //        var searchString = p.Count == 0 ? "1=1" : String.Join(" and ", p.ToArray());

        //        var query = @"select e.ID, e.LoginName, e.PositionID, e.Code, e.FirstName, e.LastName, e.Phone, e.Active, e.PositionID, p.Id, p.Name 
        //                        from [dbo].[User] e 
        //                        inner join [dbo].[MasterPosition] p on e.PositionID = p.ID
        //                        WHERE {0}
        //                        ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

        //        query = String.Format(query, searchString, String.Format("e.{0}", orderBy), orderAsc ? "ASC" : "DESC");

        //        var param = new DynamicParameters();
        //        param.Add("@Offset", (pageIndex - 1) * pageSize);
        //        param.Add("@PageSize", pageSize);

        //        var users = await SqlMapper.QueryAsync<User, MasterPosition, User>(connection, query, (employee, postion) =>
        //        {
        //            employee.Position = postion;
        //            return employee;
        //        }, splitOn: "PositionID"
        //         , param: param);

        //        query = @"select Count(*)
        //                        from [dbo].[User] e 
        //                        inner join [dbo].[MasterPosition] p on e.PositionID = p.ID
        //                        WHERE {0};";

        //        query = String.Format(query, searchString);

        //        var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);
        //        var results = users;

        //        return (results, totalrows);
        //    }
        //}
    }
}
