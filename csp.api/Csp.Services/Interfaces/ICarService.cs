using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarByPageIndex(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc);
        Task<Car> GetCarById(int id);
        Task<Car> CreateCar(Car model);
        Task<bool> UpdateCar(Car model);
        Task<bool> DeleteCar(int id);
        Task<bool> TranferCar(int carId, int customerId);
        Task<bool> ReplaceCarRegistration(int carId, string code, int provinceId);
        Task<int> GetTotalNumberCar(Dictionary<string, string> searchParams);
    }
}
