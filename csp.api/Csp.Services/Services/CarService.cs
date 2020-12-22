using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Services.Services
{
    public class CarService : BaseService, ICarService
    {

        public CarService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<Car>> GetAllCarByPageIndex(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return await _unitOfWork.CarRepository.SearchCarbyField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }
        public async Task<int> GetTotalNumberCar(Dictionary<string, string> searchParams)
        {
            return await _unitOfWork.CarRepository.GetTotalSearchCarByField(searchParams);
        }
        public async Task<Car> GetCarById(int id)
        {
            return await _unitOfWork.CarRepository.Get(id);
        }

        public async Task<Car> CreateCar(Car model)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var province = _unitOfWork.GenericRepository<MasterProvince>().Get(model.ProvinceId);
            model.Chasis = String.Format("{0} {1}", model.Code, province.Result.Name);

            searchParams.Add("Chasis", (string)model.GetType().GetProperty("Chasis").GetValue(model));
            
            if (_unitOfWork.CarRepository.SearchByField(searchParams).Result.Any()) 
            {
                foreach (var searchParam in searchParams)
                {
                    p.Add(string.Format("{0}", searchParam.Key));
                }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }
            
            model.RegisterDate = DateTime.Now;
            
            return await _unitOfWork.CarRepository.Add(model);
        }

        public async Task<bool> UpdateCar(Car model)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var province = _unitOfWork.GenericRepository<MasterProvince>().Get(model.ProvinceId);
            model.Chasis = String.Format("{0} {1}", model.Code, province.Result.Name);

            searchParams.Add("Chasis", (string)model.GetType().GetProperty("Chasis").GetValue(model));
            
            if (_unitOfWork.CarRepository.SearchByField(searchParams).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != model.Id).Any())
            {
                foreach (var searchParam in searchParams)
                {
                    p.Add(string.Format("{0}", searchParam.Key));
                }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }
            var data = _unitOfWork.GenericRepository<Car>().Get(model.Id).Result;
            model.CreatedAt = data.CreatedAt;
            model.CreatedBy = data.CreatedBy;
            model.CancelAt = data.CancelAt;
            model.CancelBy = data.CancelBy;
            return await _unitOfWork.CarRepository.Update(model);
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await _unitOfWork.CarRepository.Get(id);
            car.CancelAt = DateTime.Now;
            car.CancelBy = _unitOfWork.UserId;
            return await _unitOfWork.CarRepository.Update(car);
        }
        public async Task<bool> TranferCar(int carId, int customerId)
        {
            var car = await _unitOfWork.CarRepository.Get(carId);
            car.CustomerId = customerId;
            return await _unitOfWork.CarRepository.Update(car);
        }
        public async Task<bool> ReplaceCarRegistration(int carId, string code, int provinceId)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();
            var car = await _unitOfWork.CarRepository.Get(carId);
            car.Code = code;
            car.ProvinceId = provinceId;
           
            var province = _unitOfWork.GenericRepository<MasterProvince>().Get(provinceId);
            car.Chasis = String.Format("{0} {1}", code, province.Result.Name);
            
            searchParams.Add("Chasis", (string)car.GetType().GetProperty("Chasis").GetValue(car));

            if (_unitOfWork.CarRepository.SearchByField(searchParams).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != car.Id).Any())
            {
                foreach (var searchParam in searchParams)
                {
                    p.Add(string.Format("{0}", searchParam.Key));
                }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }
            return await _unitOfWork.CarRepository.Update(car);
        }
    }
}
