using Csp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IMasterDataService
    {
        Task<IEnumerable<object>> GetAllMasterDataByPageType<T>(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc) where T : class;
        Task<int> GetCountAllMasterDataByPageType<T>(Dictionary<string, string> searchParams) where T : class;
        Task<object> GetMasterDataById<T>(int id) where T : class;
        Task<object> Create<T>(T model) where T : class;
        Task<bool> Update<T>(int id, T model) where T : class;
        Task<bool> Delete<T>(int id) where T : class;

        Task<MasterPermisson> GetPermissionByUserId(int PositionID, int MenuID);

        Task<IEnumerable<MasterContactType>> GetAllContactType();
        Task<IEnumerable<MasterBussinessType>> GetAllBussinessType();
        Task<IEnumerable<MasterReasonDecInc>> GetAllReasonDecInc();
        Task<IEnumerable<DocumentType>> GetAllDocumentTypes();
        Task<IEnumerable<MasterVatType>> GetAllVattype();
        Task<IEnumerable<MasterVatRate>> GetAllVatRate();
        Task<IEnumerable<MasterTagDetails>> GetAllTagList();
        Task<IEnumerable<MasterTagStatus>> GetAllTagStatus();
        Task<IEnumerable<MasterPayChqType>> GetAllChequeType();
        Task<IEnumerable<MasterBank>> GetAllBank();
        Task<IEnumerable<MasterCreditCard>> GetAllCreditCard(int bankId);
        Task<IEnumerable<MasterCardUseType>> GetAllCreditCardSwipe();
        Task<IEnumerable<MasterPosition>> GetAllPosition();

        Task<IEnumerable<MasterPrefix>> GetAllPrefixName();
        Task<IEnumerable<MasterNextService>> GetAllNextService();
        Task<IEnumerable<MasterNextServiceSub>> GetAllSubNextService(int nextserviceId);
        Task<IEnumerable<MasterProvince>> GetAllProvince();
        Task<IEnumerable<MasterDistrict>> GetAllDistrictByProvinceId(int provinceId);
        Task<IEnumerable<MasterSubDistrict>> GetAllSubDistrictByProvinceId(int provinceId, int districtId);

        Task<IEnumerable<MasterDot>> GetAllDot();

        Task<IEnumerable<MasterCarType>> GetAllCarType();
        Task<IEnumerable<MasterCarBrand>> GetAllCarBrand();
        Task<IEnumerable<MasterCarModel>> GetAllCarModel();
        Task<IEnumerable<MasterCarBrand>> GetAllCarBrandByCarTypeId(int cartypeId);
        Task<IEnumerable<MasterCarModel>> GetAllCarModelByCarBrandId(int carbrandId);
        Task<IEnumerable<MasterCarSubModel>> GetAllCarSubModelByCarModelId(int carmodelId);
        Task<IEnumerable<MasterCarGear>> GetAllCarGear();

        Task<IEnumerable<MasterProGroup>> GetAllProductGroups();
        Task<IEnumerable<MasterProType>> GetAllProductTypes();
        Task<IEnumerable<MasterProBrand>> GetAllProductBrands();
        Task<IEnumerable<MasterProSize>> GetAllProductSize();
        Task<IEnumerable<MasterProType>> GetAllProductTypeByProGroupId(int progroupId);
        Task<IEnumerable<MasterProBrand>> GetAllProductBrandByProTypeId(int protypeId);
        Task<IEnumerable<MasterPromodel>> GetAllProductModelByProBrandId(int probrandId);
        Task<IEnumerable<MasterLocation>> GetAllProductLocation();
        Task<IEnumerable<MasterProUnit>> GetAllProUnit();

    }
}
