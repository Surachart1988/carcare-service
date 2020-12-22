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
    public class ContactTypesService : BaseService, IContactTypesService
    {

        public ContactTypesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<Contact>> GetAllVenderByPageIndex(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return await _unitOfWork.ContactTypesRepository.SearchVenderbyField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }
        public async Task<Contact> GetVenderById(int id)
        {
            return await _unitOfWork.ContactTypesRepository.Get(id);
        }
        public async Task<Contact> CreateVender(Contact model)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            searchParams.Add("Name", (string)model.GetType().GetProperty("Name").GetValue(model));
            searchParams.Add("TaxId", (string)model.GetType().GetProperty("TaxId").GetValue(model));

            if (_unitOfWork.ContactTypesRepository.CheckDuplicateVender(searchParams).Result.Any())
            {
                foreach (var searchParam in searchParams)
                {
                    p.Add(string.Format("{0}", searchParam.Key));
                }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }

            string code;
            if (_unitOfWork.ContactTypesRepository.GetAll().Result.Where(v => v.Code.Contains("V")).OrderByDescending(u => u.Id).FirstOrDefault() == null)
                code = "0";
            else
                code = _unitOfWork.ContactTypesRepository.GetAll().Result.Where(v => v.Code.Contains("V")).OrderByDescending(u => u.Id).FirstOrDefault().Code.Split("V")[1];

            model.Code = String.Format("V{0:D6}", Convert.ToInt64(code) + 1);
            model.Types = 1;
            return await _unitOfWork.ContactTypesRepository.Add(model);
        }
        public async Task<bool> UpdateVender(Contact model)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            searchParams.Add("Name", (string)model.GetType().GetProperty("Name").GetValue(model));
            searchParams.Add("TaxId", (string)model.GetType().GetProperty("TaxId").GetValue(model));

            if (_unitOfWork.ContactTypesRepository.CheckDuplicateVender(searchParams).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != model.Id).Any())
            {
                foreach (var searchParam in searchParams)
                {
                    p.Add(string.Format("{0}", searchParam.Key));
                }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }
            
            return await _unitOfWork.ContactTypesRepository.Update(model);
        }

       
        public async Task<int> GetTotalNumberVender(Dictionary<string, string> searchParams)
        {
            return await _unitOfWork.ContactTypesRepository.GetTotalSearchVenderByField(searchParams);
        }



        public async Task<IEnumerable<Contact>> GetAllCustomerByPageIndex(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return await _unitOfWork.ContactTypesRepository.SearchCustomerbyField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }
        public async Task<Contact> GetCustomerById(int id)
        {
            return await _unitOfWork.ContactTypesRepository.Get(id);
        }
        public async Task<Contact> CreateCustomer(Contact model)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            searchParams.Add("Name", (string)model.GetType().GetProperty("Name").GetValue(model));
            searchParams.Add("TaxId", (string)model.GetType().GetProperty("TaxId").GetValue(model));

            if (_unitOfWork.ContactTypesRepository.CheckDuplicateCustomer(searchParams).Result.Any())
            {
                    foreach (var searchParam in searchParams)
                    {
                        p.Add(string.Format("{0}", searchParam.Key));
                    }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }
                
            string code;
            if (_unitOfWork.ContactTypesRepository.GetAll().Result.Where(c => c.Code.Contains("C")).OrderByDescending(u => u.Id).FirstOrDefault() == null)
                code = "0";
            else
                code = _unitOfWork.ContactTypesRepository.GetAll().Result.Where(c => c.Code.Contains("C")).OrderByDescending(u => u.Id).FirstOrDefault().Code.Split("C")[1];

            model.Code = String.Format("C{0:D6}", Convert.ToInt64(code) + 1);
            model.Types = 2;
            model.VatTypeId = 1;
            return await _unitOfWork.ContactTypesRepository.Add(model);
        }

        public async Task<bool> UpdateCustomer(Contact model)
        {
            var p = new ArrayList();
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            searchParams.Add("Name", (string)model.GetType().GetProperty("Name").GetValue(model));

            if (_unitOfWork.ContactTypesRepository.CheckDuplicateCustomer(searchParams).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != model.Id).Any())
            {
                foreach (var searchParam in searchParams)
                {
                    p.Add(string.Format("{0}", searchParam.Key));
                }
                var field = String.Join(" OR ", p.ToArray());
                throw new DataDuplicateException(String.Format("Data {0} is duplicate", field));
            }
            var oldcustomerdata = _unitOfWork.ContactTypesRepository.Get(model.Id);
            var data = _unitOfWork.GenericRepository<Contact>().Get(model.Id).Result;
            if (oldcustomerdata.Result.Active != false)
            {
                if (model.Active == false)
                {
                    model.CancelAt = DateTime.Now;
                    model.CancelBy = _unitOfWork.UserId;
                }
            }
            else
            {
                model.CancelAt = data.CancelAt;
                model.CancelBy = data.CancelBy;
            }
            model.Code = data.Code;
            model.Types = data.Types;
            model.CreatedAt = data.CreatedAt;
            model.CreatedBy = data.CreatedBy;

            return await _unitOfWork.ContactTypesRepository.Update(model);
        }

        public async Task<int> GetTotalNumberCustomer(Dictionary<string, string> searchParams)
        {
            return await _unitOfWork.ContactTypesRepository.GetTotalSearchCustomerByField(searchParams);
        }
    }
}
