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
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(IConnectionFactory connectionFactory, int userId) : base(connectionFactory, userId)
        {
        }
        
        public async Task<IEnumerable<Car>> SearchCarbyField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
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

                var query = String.Format(@"SELECT car.ID, car.Code, car.RegisterDate, car.Color, car.Year, car.CancelAt, province.ID AS ProvinceID, province.Name, cartype.ID AS CarTypeID, cartype.Name, carbrand.ID AS CarBrandID , carbrand.Name, carmodel.ID AS CarModelID, carmodel.Name 
                    FROM Car as car
                    INNER JOIN MasterProvince AS province ON car.ProvinceID = province.ID
                    INNER JOIN MasterCarType AS cartype ON car.CarTypeID = cartype.ID
                    INNER JOIN MasterCarBrand AS carbrand ON car.CarBrandID = carbrand.ID
                    INNER JOIN MasterCarModel AS carmodel ON car.CarModelID = carmodel.ID
                    INNER JOIN Contact AS customer ON car.CustomerID = customer.ID
                    WHERE {0} ORDER BY {1} {2} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;", searchString, orderBy, orderAsc ? "ASC" : "DESC");

                var param = new DynamicParameters();
                param.Add("@Offset", (pageIndex - 1) * pageSize);
                param.Add("@PageSize", pageSize);

                var contacts = await SqlMapper.QueryAsync<Car, MasterProvince, MasterCarType, MasterCarBrand, MasterCarModel, Car>(connection, query, (car, province, cartype, carbrand, carmodel) =>
                {
                    car.Province = province;
                    car.CarType = cartype;
                    car.CarBrand = carbrand;
                    car.CarModel = carmodel;
                    return car;
                }, splitOn: "ProvinceID,CarTypeID,CarBrandID,CarModelID"
                 , param: param);

                return (contacts);
            }
        }

        public async Task<int> GetTotalSearchCarByField(Dictionary<string, string> searchParams)
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
                    FROM Car as car
                    INNER JOIN MasterProvince AS province ON car.ProvinceID = province.ID
                    INNER JOIN MasterCarType AS cartype ON car.CarTypeID = cartype.ID
                    INNER JOIN MasterCarBrand AS carbrand ON car.CarBrandID = carbrand.ID
                    INNER JOIN MasterCarModel AS carmodel ON car.CarModelID = carmodel.ID
                    INNER JOIN Contact AS customer ON car.CustomerID = customer.ID
                    WHERE {0};";

                query = String.Format(query, searchString);

                var totalrows = await SqlMapper.QueryFirstAsync<int>(connection, query);
              
                return (totalrows);
            }
        }
    }
}
