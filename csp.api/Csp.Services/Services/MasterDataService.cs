using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Services.Services
{
    public class MasterDataService : BaseService, IMasterDataService
    {
        public MasterDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //_cache = cache;
        }

        public async Task<IEnumerable<object>> GetAllMasterDataByPageType<T>(Dictionary<string, string> searchParams, int pageIndex, int pageSize, string orderBy, bool orderAsc) where T : class
        {
            IEnumerable<object> result = null;

            switch (typeof(T).Name)
            {
                case nameof(MasterProType):
                case nameof(MasterProBrand):
                case nameof(MasterPromodel):
                case nameof(MasterNextServiceSub):
                case nameof(MasterCarBrand):
                case nameof(MasterCarModel):
                case nameof(MasterCarSubModel):
                case nameof(MasterAssessment):
                    result = await _unitOfWork.GenericRepository<object>().MasterDataSearchByField(searchParams, $"V_{typeof(T).Name}", pageIndex, pageSize, orderBy, orderAsc); break;
                case nameof(MasterContactType)://"MasterContactType":
                    var objList = (await _unitOfWork.GenericRepository<MasterContactType>().MasterDataSearchByField(searchParams, typeof(T).Name, pageIndex, pageSize, orderBy, orderAsc));
                    result = objList.Select(s => new { s.Id, s.Code, s.Name, ContactPayTypeName = s.ContactPayTypeId == 1 ? "เงินสด" : "เครดิต", s.UpdatedAt }); break;
                default:
                    result = await _unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name, pageIndex, pageSize, orderBy, orderAsc); break;
            }
            return result;
        }

        public async Task<int> GetCountAllMasterDataByPageType<T>(Dictionary<string, string> searchParams) where T : class
        {
            int result = 0;

            switch (typeof(T).Name)
            {
                case nameof(MasterProType):
                case nameof(MasterProBrand):
                case nameof(MasterPromodel):
                case nameof(MasterNextServiceSub):
                case nameof(MasterCarBrand):
                case nameof(MasterCarModel):
                case nameof(MasterCarSubModel):
                case nameof(MasterAssessment):
                    result = await _unitOfWork.GenericRepository<object>().GetCountMasterDataSearchByField(searchParams, $"V_{typeof(T).Name}"); break;
                case nameof(MasterContactType)://"MasterContactType":
                    result = (await _unitOfWork.GenericRepository<MasterContactType>().GetCountMasterDataSearchByField(searchParams, typeof(T).Name)); break;
                default:
                    result = await _unitOfWork.GenericRepository<T>().GetCountMasterDataSearchByField(searchParams, typeof(T).Name); break;
            }
            return result;
        }

        public async Task<object> GetMasterDataById<T>(int id) where T : class
        {
            object result = null;
            switch (typeof(T).Name)
            {
                case nameof(MasterAssessment):
                    var msAssment = await _unitOfWork.GenericRepository<MasterAssessment>().Get(id);
                    if (msAssment == null)
                        throw new DataNotFoundException("Data not found");

                    msAssment.MasterAssessmentDetails = _unitOfWork.GenericRepository<MasterAssessmentDetails>().GetAll().Result.Where(w => w.AssessmentId == id).ToArray();
                    result = msAssment;
                    break;

                case nameof(MasterPosition):
                    var msPosition = await _unitOfWork.GenericRepository<MasterPosition>().Get(id);
                    if (msPosition == null)
                        throw new DataNotFoundException("Data not found");

                    msPosition.MasterPermisson = _unitOfWork.GenericRepository<MasterPermisson>().GetAll().Result.Where(w => w.PositionId == id).ToArray();
                    result = msPosition;
                    break;

                default:
                    result = await _unitOfWork.GenericRepository<T>().Get(id);
                    break;
            }

            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<object> Create<T>(T model) where T : class
        {
            object result = null;
            Dictionary<string, string> searchParams = new Dictionary<string, string>
            {
                { "Name", (string)model.GetType().GetProperty("Name").GetValue(model) }
            };

            switch (typeof(T).Name)
            {
                case nameof(MasterDot):
                    #region dot
                    var _dotyear = (string)model.GetType().GetProperty("Name").GetValue(model);
                    var dotList = _unitOfWork.GenericRepository<MasterDot>().GetAll().Result.Select(s => s.Name.Substring(2, 2));
                    if (dotList.Where(w => w.Contains(_dotyear.Substring(2, 2))).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var msDOT = new List<MasterDot>();
                    for (int i = 1; i <= 52; i++)
                    {
                        msDOT.Add(new MasterDot { Name = $"{i.ToString("D2")}{_dotyear.Substring(2, 2)}" });
                    }
                    result = await _unitOfWork.GenericRepository<MasterDot>().AddRageItems(@"INSERT INTO [dbo].[MasterDOT]
            ([Name],[CreatedAt],[UpdatedAt],[CreatedBy],[UpdatedBy]) 
            VALUES
            (@Name, @CreatedAt, @UpdatedAt, @CreatedBy, @UpdatedBy)", msDOT);
                    break;
                #endregion

                case nameof(MasterAssessment):

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var msAssment = await _unitOfWork.GenericRepository<T>().Add(model);
                    if (msAssment == null)
                        throw new Exception("Insert data failed");

                    var reqAssmentDetail = (IEnumerable<MasterAssessmentDetails>)model.GetType().GetProperty("MasterAssessmentDetails").GetValue(model);
                    reqAssmentDetail = reqAssmentDetail.Select(s => { s.AssessmentId = (int)msAssment.GetType().GetProperty("Id").GetValue(msAssment); return s; }).ToList();
                    result = await _unitOfWork.GenericRepository<MasterAssessmentDetails>().AddRageItems(@"INSERT INTO [dbo].[MasterAssessmentDetails]
            ([Name],[AssessmentID],[CreatedAt],[UpdatedAt],[CreatedBy],[UpdatedBy]) 
            VALUES 
            (@Name, @AssessmentID, @CreatedAt, @UpdatedAt, @CreatedBy, @UpdatedBy)", reqAssmentDetail);
                    break;
                //no manage 
                //case "documenttype": break;

                //no manage 
                //case "conditiontaxdeduction": break;
                //case "taxdeductiontype": break;

                case nameof(MasterPosition):
                    #region position
                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var msPosition = await _unitOfWork.GenericRepository<T>().Add(model);
                    if (msPosition == null)
                        throw new Exception("Insert data failed");

                    var reqPRMS = (IEnumerable<MasterPermisson>)model.GetType().GetProperty("MasterPermisson").GetValue(model);
                    reqPRMS = reqPRMS.Select(s => { s.PositionId = (int)msPosition.GetType().GetProperty("Id").GetValue(msPosition); return s; }).ToList();
                    result = await _unitOfWork.GenericRepository<MasterPermisson>().AddRageItems(@"INSERT INTO [dbo].[MasterPermisson]
           ([PositionID],[MenuID],[CreatePermisson],[EditPermisson],[ViewPermisson],[DeletePermisson],[PrintPermisson],[CreatedAt],[UpdatedAt],[CreatedBy],[UpdatedBy])
            VALUES
           (@PositionID,@MenuID,@CreatePermisson,@EditPermisson,@ViewPermisson,@DeletePermisson,@PrintPermisson,@CreatedAt,@UpdatedAt,@CreatedBy,@UpdatedBy)", reqPRMS);
                    break;
                #endregion

                default:
                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Any())
                        throw new DataDuplicateException("Data is duplicate");


                    // generate CODE for create contacttype
                    if (model is MasterContactType)
                        (model as MasterContactType).Code = GenerateContactTypeCode();

                    result = await _unitOfWork.GenericRepository<T>().Add(model);
                    if (result == null) throw new Exception("Insert data failed"); break;
            }

            return result;
        }

        public async Task<bool> Update<T>(int id, T model) where T : class
        {
            bool result = false; string ModelCode = null; string ModelName = null;
            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            if (model.GetType().GetProperty("Name") != null)
                ModelName = (string)model.GetType().GetProperty("Name").GetValue(model);
            if (model.GetType().GetProperty("Code") != null)
                ModelCode = (string)model.GetType().GetProperty("Code").GetValue(model);

            if (ModelName != null)
                searchParams.Add("Name", ModelName);
            if (ModelCode != null)
                searchParams.Add("Code", ModelCode);

            switch (typeof(T).Name)
            {
                case nameof(MasterProType):
                    #region MasterProType
                    var msProType = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msProType == null)
                        throw new DataNotFoundException("Data not found");

                    var newProGroupId = (int)model.GetType().GetProperty("ProGroupId").GetValue(model);
                    var currentProGroupId = (int)msProType.GetType().GetProperty("ProGroupId").GetValue(msProType);
                    if (newProGroupId != currentProGroupId)
                    {
                        if (_unitOfWork.GenericRepository<MasterProBrand>().GetAll().Result.Where(w => w.ProTypeId == id).Any())
                            throw new NotAccpteableException("product type can not modify");
                    }

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    msProType.GetType().GetProperty("ProGroupId").SetValue(msProType, newProGroupId);
                    if (ModelCode != null)
                        msProType.GetType().GetProperty("Code").SetValue(msProType, ModelCode);
                    if (ModelName != null)
                        msProType.GetType().GetProperty("Name").SetValue(msProType, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msProType);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterProBrand):
                    #region MasterProBrand
                    var msProBrand = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msProBrand == null)
                        throw new DataNotFoundException("Data not found");

                    var newProTypeId = (int)model.GetType().GetProperty("ProTypeId").GetValue(model);
                    var currentProTypeId = (int)msProBrand.GetType().GetProperty("ProTypeId").GetValue(msProBrand);
                    if (newProTypeId != currentProTypeId)
                    {
                        if (_unitOfWork.GenericRepository<MasterPromodel>().GetAll().Result.Where(w => w.ProBrandId == id).Any())
                            throw new NotAccpteableException("product brand can not modify");
                    }

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    msProBrand.GetType().GetProperty("ProTypeId").SetValue(msProBrand, newProTypeId);
                    if (ModelName != null)
                        msProBrand.GetType().GetProperty("Name").SetValue(msProBrand, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msProBrand);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterPromodel):
                    #region MasterPromodel
                    var msProModel = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msProModel == null)
                        throw new DataNotFoundException("Data not found");

                    var newProBrandId = (int)model.GetType().GetProperty("ProBrandId").GetValue(model);
                    var currentProBrandId = (int)msProModel.GetType().GetProperty("ProBrandId").GetValue(msProModel);
                    if (newProBrandId != currentProBrandId)
                    {
                        if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.ProModelId == id).Any())
                            throw new NotAccpteableException("product model can not modify");
                    }

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    msProModel.GetType().GetProperty("ProBrandId").SetValue(msProModel, newProBrandId);
                    if (ModelName != null)
                        msProModel.GetType().GetProperty("Name").SetValue(msProModel, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msProModel);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterProSize):
                    #region MasterProSize
                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var msProSize = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msProSize == null)
                        throw new DataNotFoundException("Data not found");

                    if (ModelName != null)
                        msProSize.GetType().GetProperty("Name").SetValue(msProSize, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msProSize);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterCarBrand):
                    #region MasterCarBrand
                    var msCarBrand = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msCarBrand == null)
                        throw new DataNotFoundException("Data not found");

                    var newCarTypeId = (int)model.GetType().GetProperty("CarTypeId").GetValue(model);
                    var currentCarTypeId = (int)msCarBrand.GetType().GetProperty("CarTypeId").GetValue(msCarBrand);
                    if (newCarTypeId != currentCarTypeId)
                    {
                        if (_unitOfWork.GenericRepository<MasterCarModel>().GetAll().Result.Where(w => w.CarBrandId == id).Any())
                            throw new NotAccpteableException("car brand can not modify");
                    }

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    msCarBrand.GetType().GetProperty("CarTypeId").SetValue(msCarBrand, newCarTypeId);
                    if (ModelName != null)
                        msCarBrand.GetType().GetProperty("Name").SetValue(msCarBrand, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msCarBrand);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterCarModel):
                    #region MasterCarModel
                    var msCarModel = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msCarModel == null)
                        throw new DataNotFoundException("Data not found");

                    var newBrandId = (int)model.GetType().GetProperty("CarBrandId").GetValue(model);
                    var currentBrandId = (int)msCarModel.GetType().GetProperty("CarBrandId").GetValue(msCarModel);
                    if (newBrandId != currentBrandId)
                    {
                        if (_unitOfWork.GenericRepository<MasterCarSubModel>().GetAll().Result.Where(w => w.CarModelId == id).Any())
                            throw new NotAccpteableException("car model can not modify");
                    }

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    msCarModel.GetType().GetProperty("CarBrandId").SetValue(msCarModel, newBrandId);
                    if (ModelName != null)
                        msCarModel.GetType().GetProperty("Name").SetValue(msCarModel, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msCarModel);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterCarSubModel):
                    #region MasterCarSubModel
                    var msCarSubModel = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msCarSubModel == null)
                        throw new DataNotFoundException("Data not found");

                    var newCarModelId = (int)model.GetType().GetProperty("CarModelId").GetValue(model);
                    var currentCarModelId = (int)msCarSubModel.GetType().GetProperty("CarModelId").GetValue(msCarSubModel);
                    if (newCarModelId != currentCarModelId)
                    {
                        if (_unitOfWork.GenericRepository<Car>().GetAll().Result.Where(w => w.CarSubModelId == id).Any())
                            throw new NotAccpteableException("car submodel can not modify");
                    }

                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    msCarSubModel.GetType().GetProperty("CarModelId").SetValue(msCarSubModel, newCarModelId);
                    if (ModelName != null)
                        msCarSubModel.GetType().GetProperty("Name").SetValue(msCarSubModel, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(msCarSubModel);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
                #endregion

                case nameof(MasterAssessment):
                    #region MasterAssessment
                    if (_unitOfWork.GenericRepository<MasterAssessment>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => w.Id != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var msAssment = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msAssment == null)
                        throw new DataNotFoundException("Data not found");

                    msAssment.GetType().GetProperty("Name").SetValue(msAssment, ModelName);
                    msAssment.GetType().GetProperty("Status").SetValue(msAssment, (bool)model.GetType().GetProperty("Status").GetValue(model));
                    result = await _unitOfWork.GenericRepository<T>().Update(msAssment);
                    if (!result)
                        throw new Exception("Update failed");

                    var reqAssmentDetail = (IEnumerable<MasterAssessmentDetails>)model.GetType().GetProperty("MasterAssessmentDetails").GetValue(model);
                    var msAssmentDetail = _unitOfWork.GenericRepository<MasterAssessmentDetails>().GetAll().Result.Where(w => w.AssessmentId == id);

                    var objAssmentDetail = msAssmentDetail.GroupJoin(reqAssmentDetail,
                        src => src.AssessmentId,
                        d => d.AssessmentId,
                        (src, des) => new { Master = src, Des = des.ToArray() })
                        .Select((s, i) => new MasterAssessmentDetails
                        {
                            Id = s.Master.Id,
                            AssessmentId = s.Master.AssessmentId,
                            Name = s.Des[i].Name,
                            CreatedAt = s.Master.CreatedAt,
                            CreatedBy = s.Master.CreatedBy
                        });
                    result = await _unitOfWork.GenericRepository<MasterAssessmentDetails>().UpdateRageItems(@"UPDATE [dbo].[MasterAssessmentDetails]
                               SET [Name] = @Name
                                  ,[AssessmentID] = @AssessmentID
                                  ,[CreatedAt] = @CreatedAt
                                  ,[UpdatedAt] = @UpdatedAt
                                  ,[CreatedBy] = @CreatedBy
                                  ,[UpdatedBy] = @UpdatedBy
                             WHERE Id = @Id", objAssmentDetail);
                    if (!result)
                        throw new Exception("Update AssmentDetail failed");
                    break;
                #endregion

                //no manage 
                //case "dot":

                //no manage 
                //case "documenttype": break;

                //no manage 
                //case "conditiontaxdeduction": break;
                //case "taxdeductiontype": break;
                case nameof(MasterPosition):
                    #region position
                    if (_unitOfWork.GenericRepository<MasterPosition>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => w.Id != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var msPosition = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (msPosition == null)
                        throw new DataNotFoundException("Data not found");

                    msPosition.GetType().GetProperty("Name").SetValue(msPosition, ModelName);
                    result = await _unitOfWork.GenericRepository<T>().Update(msPosition);
                    if (!result)
                        throw new Exception("Update failed");

                    var reqPRMS = (IEnumerable<MasterPermisson>)model.GetType().GetProperty("MasterPermisson").GetValue(model);
                    var msPRMS = _unitOfWork.GenericRepository<MasterPermisson>().GetAll().Result.Where(w => w.PositionId == id);
                    var objPRMS = msPRMS.GroupJoin(reqPRMS,
                        src => (src.PositionId, src.MenuId),
                        d => (d.PositionId, d.MenuId),
                        (src, des) => new { Master = src, Des = des.FirstOrDefault() })
                        .Select(s => new MasterPermisson
                        {
                            Id = s.Master.Id,
                            PositionId = s.Master.PositionId,
                            MenuId = s.Master.MenuId,
                            CreatePermisson = s.Des.CreatePermisson,
                            EditPermisson = s.Des.EditPermisson,
                            ViewPermisson = s.Des.ViewPermisson,
                            DeletePermisson = s.Des.DeletePermisson,
                            PrintPermisson = s.Des.PrintPermisson,
                            CreatedAt = s.Master.CreatedAt,
                            CreatedBy = s.Master.CreatedBy
                        });

                    result = await _unitOfWork.GenericRepository<MasterPermisson>().UpdateRageItems(@"UPDATE [dbo].[MasterPermisson]
                               SET [PositionID] = @PositionID
                                  ,[MenuID] = @MenuID
                                  ,[CreatePermisson] = @CreatePermisson
                                  ,[EditPermisson] = @EditPermisson
                                  ,[ViewPermisson] = @ViewPermisson
                                  ,[DeletePermisson] = @DeletePermisson
                                  ,[PrintPermisson] = @PrintPermisson
                                  ,[CreatedAt] = @CreatedAt
                                  ,[UpdatedAt] = @UpdatedAt
                                  ,[CreatedBy] = @CreatedBy
                                  ,[UpdatedBy] = @UpdatedBy
                             WHERE Id = @Id", objPRMS.ToArray());
                    if (!result)
                        throw new Exception("Update permission failed");
                    break;
                #endregion

                default:
                    if (_unitOfWork.GenericRepository<T>().MasterDataSearchByField(searchParams, typeof(T).Name).Result.Where(w => (int)w.GetType().GetProperty("Id").GetValue(w) != id).Any())
                        throw new DataDuplicateException("Data is duplicate");

                    var getModel = await _unitOfWork.GenericRepository<T>().Get(id);
                    if (getModel == null)
                        throw new DataNotFoundException("Data not found");

                    if (ModelCode != null)
                        getModel.GetType().GetProperty("Code").SetValue(getModel, ModelCode);
                    if (ModelName != null)
                        getModel.GetType().GetProperty("Name").SetValue(getModel, ModelName);

                    result = await _unitOfWork.GenericRepository<T>().Update(getModel);
                    if (!result)
                        throw new Exception("Update failed");
                    break;
            }
            return result;
        }

        public async Task<bool> Delete<T>(int id) where T : class
        {
            bool result = false;

            switch (typeof(T).Name)
            {
                case nameof(MasterProGroup):
                    #region MasterProGroup
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.ProGroupId == id).Any())
                        throw new NotAccpteableException("product group can not delete");

                    if (_unitOfWork.GenericRepository<MasterProType>().GetAll().Result.Where(w => w.ProGroupId == id).Any())
                        throw new NotAccpteableException("product group can not delete");
                    break;
                #endregion

                case nameof(MasterProType):
                    #region MasterProType
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.ProTypeId == id).Any())
                        throw new NotAccpteableException("product type can not delete");

                    if (_unitOfWork.GenericRepository<MasterProBrand>().GetAll().Result.Where(w => w.ProTypeId == id).Any())
                        throw new NotAccpteableException("product type can not delete");
                    break;
                #endregion

                case nameof(MasterProBrand):
                    #region MasterProBrand
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.ProBrandId == id).Any())
                        throw new NotAccpteableException("product brand can not delete");

                    if (_unitOfWork.GenericRepository<MasterPromodel>().GetAll().Result.Where(w => w.ProBrandId == id).Any())
                        throw new NotAccpteableException("product brand can not delete");
                    break;
                #endregion

                case nameof(MasterPromodel):
                    #region MasterPromodel
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.ProModelId == id).Any())
                        throw new NotAccpteableException("product model can not delete");
                    break;
                #endregion

                case nameof(MasterProSize):
                    #region MasterProSize
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.ProSizeId == id).Any())
                        throw new NotAccpteableException("product size can not delete");
                    break;
                #endregion

                case nameof(MasterProUnit):
                    #region MasterProUnit
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.SaleUnitId == id).Any())
                        throw new NotAccpteableException("product unit can not delete");

                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.BuyUnitId == id).Any())
                        throw new NotAccpteableException("product unit can not delete");
                    break;
                #endregion

                case nameof(MasterLocation):
                    #region MasterLocation
                    if (_unitOfWork.GenericRepository<SaleDetail>().GetAll().Result.Where(w => w.LocationId == id).Any())
                        throw new NotAccpteableException("location can not delete");

                    if (_unitOfWork.GenericRepository<MasterProStock>().GetAll().Result.Where(w => w.LocationId == id).Any())
                        throw new NotAccpteableException("location can not delete");
                    break;
                #endregion

                //no manage 
                //case "dot":

                case nameof(MasterNextService):
                    #region MasterNextService
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.NextServiceId == id).Any())
                        throw new NotAccpteableException("nextservice can not delete");

                    if (_unitOfWork.GenericRepository<MasterNextServiceSub>().GetAll().Result.Where(w => w.NextServiceId == id).Any())
                        throw new NotAccpteableException("nextservice can not delete");
                    break;
                #endregion

                case nameof(MasterNextServiceSub):
                    #region MasterNextService
                    if (_unitOfWork.GenericRepository<Product>().GetAll().Result.Where(w => w.NextServiceSubId == id).Any())
                        throw new NotAccpteableException("subnextservice can not delete");
                    break;
                #endregion

                case nameof(MasterCarType):
                    #region MasterCarType
                    if (_unitOfWork.GenericRepository<Car>().GetAll().Result.Where(w => w.CarTypeId == id).Any())
                        throw new NotAccpteableException("car type can not delete");

                    if (_unitOfWork.GenericRepository<MasterCarBrand>().GetAll().Result.Where(w => w.CarTypeId == id).Any())
                        throw new NotAccpteableException("car type can not delete");
                    break;
                #endregion

                case nameof(MasterCarBrand):
                    #region MasterCarBrand
                    if (_unitOfWork.GenericRepository<Car>().GetAll().Result.Where(w => w.CarBrandId == id).Any())
                        throw new NotAccpteableException("car brand can not delete");

                    if (_unitOfWork.GenericRepository<MasterCarModel>().GetAll().Result.Where(w => w.CarBrandId == id).Any())
                        throw new NotAccpteableException("car brand can not delete");
                    break;
                #endregion

                case nameof(MasterCarModel):
                    #region MasterCarModel
                    if (_unitOfWork.GenericRepository<Car>().GetAll().Result.Where(w => w.CarModelId == id).Any())
                        throw new NotAccpteableException("car model can not delete");

                    if (_unitOfWork.GenericRepository<MasterCarSubModel>().GetAll().Result.Where(w => w.CarModelId == id).Any())
                        throw new NotAccpteableException("car model can not delete");
                    break;
                #endregion

                case nameof(MasterCarSubModel):
                    #region MasterCarSubModel
                    if (_unitOfWork.GenericRepository<Car>().GetAll().Result.Where(w => w.CarSubModelId == id).Any())
                        throw new NotAccpteableException("car submodel can not delete");
                    break;
                #endregion

                case nameof(MasterCheckList):
                    #region MasterCheckList
                    if (_unitOfWork.GenericRepository<CarCheckDetail>().GetAll().Result.Where(w => w.CheckListId == id).Any())
                        throw new NotAccpteableException("car checklist can not delete");

                    if (_unitOfWork.GenericRepository<CarChecklistDetail>().GetAll().Result.Where(w => w.CheckListId == id).Any())
                        throw new NotAccpteableException("car checklist can not delete");
                    break;
                #endregion

                case nameof(MasterCarGear):
                    #region MasterCarGear
                    if (_unitOfWork.GenericRepository<Car>().GetAll().Result.Where(w => w.CarGearId == id).Any())
                        throw new NotAccpteableException("car gear can not delete");
                    break;
                #endregion

                case nameof(MasterContactType):
                    #region MasterContactType
                    if (_unitOfWork.GenericRepository<Contact>().GetAll().Result.Where(w => w.ContactTypeId == id).Any())
                        throw new NotAccpteableException("contact type can not delete");

                    if (_unitOfWork.GenericRepository<ProductSalePriceGroup>().GetAll().Result.Where(w => w.ContactTypeId == id).Any())
                        throw new NotAccpteableException("contact type can not delete");
                    break;
                #endregion

                case nameof(MasterBussinessType):
                    #region MasterBussinessType
                    if (_unitOfWork.GenericRepository<Contact>().GetAll().Result.Where(w => w.BussTypeId == id).Any())
                        throw new NotAccpteableException("bussiness type can not delete");
                    break;
                #endregion

                case nameof(MasterReasonDecInc):
                    #region MasterReasonDecInc
                    if (_unitOfWork.GenericRepository<SaleDetail>().GetAll().Result.Where(w => w.ReasonIncDecId == id).Any())
                        throw new NotAccpteableException("reasonDecInc can not delete");
                    break;
                #endregion

                case nameof(MasterAssessment):
                    #region MasterAssessment
                    var msAssessmentDetail = _unitOfWork.GenericRepository<MasterAssessmentDetails>().GetAll().Result.Where(w => w.AssessmentId == id);
                    result = await _unitOfWork.GenericRepository<MasterAssessmentDetails>().DeleteRageItems("DELETE FROM [dbo].[MasterAssessmentDetails] WHERE Id = @Id", msAssessmentDetail.ToArray());
                    if (!result)
                        throw new Exception("Delete AssessmentDetails failed");
                    #endregion
                    break;

                case nameof(MasterTagStatus):
                    #region MasterTagStatus
                    if (_unitOfWork.GenericRepository<Sale>().GetAll().Result.Where(w => w.TagStatusId == id).Any())
                        throw new NotAccpteableException("tagstatus can not delete");
                    break;
                #endregion

                //no manage 
                //case "documenttype": break;

                case nameof(MasterBank):
                    #region MasterBank
                    if (_unitOfWork.GenericRepository<Sale>().GetAll().Result.Where(w => w.BankId == id).Any())
                        throw new NotAccpteableException("bank can not delete");

                    if (_unitOfWork.GenericRepository<Payment>().GetAll().Result.Where(w => w.BankId == id).Any())
                        throw new NotAccpteableException("bank can not delete");

                    if (_unitOfWork.GenericRepository<MasterBookBank>().GetAll().Result.Where(w => w.BankId == id).Any())
                        throw new NotAccpteableException("bank can not delete");

                    if (_unitOfWork.GenericRepository<MasterCreditCard>().GetAll().Result.Where(w => w.BankId == id).Any())
                        throw new NotAccpteableException("bank can not delete");
                    break;
                #endregion

                case nameof(MasterCreditCard):
                    #region MasterCreditCard
                    if (_unitOfWork.GenericRepository<Payment>().GetAll().Result.Where(w => w.CreditcardId == id).Any())
                        throw new NotAccpteableException("creditcard can not delete");
                    break;
                #endregion

                case nameof(MasterPayChqType):
                    #region MasterPayChqType
                    if (_unitOfWork.GenericRepository<Payment>().GetAll().Result.Where(w => w.PayChqTypeId == id).Any())
                        throw new NotAccpteableException("paychqtype can not delete");

                    if (_unitOfWork.GenericRepository<Sale>().GetAll().Result.Where(w => w.PayChqTypeId == id).Any())
                        throw new NotAccpteableException("paychqtype can not delete");
                    break;
                #endregion

                case nameof(MasterCardUseType):
                    #region creditcardswipe
                    if (_unitOfWork.GenericRepository<Payment>().GetAll().Result.Where(w => w.CardUseTypeId == id).Any())
                        throw new NotAccpteableException("cardusetype can not delete");
                    break;
                #endregion

                case nameof(MasterVatRate):
                    #region inputtaxrate,outputtaxrate
                    if (_unitOfWork.GenericRepository<Sale>().GetAll().Result.Where(w => w.VatRateId == id).Any())
                        throw new NotAccpteableException("vatrate can not delete");

                    if (_unitOfWork.GenericRepository<Contact>().GetAll().Result.Where(w => w.VatRateId == id).Any())
                        throw new NotAccpteableException("vatrate can not delete");
                    break;
                #endregion

                //no manage 
                //case "conditiontaxdeduction": break;
                //case "taxdeductiontype": break;

                case nameof(MasterPosition):
                    #region position
                    if (_unitOfWork.UserRepository.GetAll().Result.Where(w => w.PositionId == id).Any())
                        throw new NotAccpteableException("position can not delete");

                    var msPRMS = _unitOfWork.GenericRepository<MasterPermisson>().GetAll().Result.Where(w => w.PositionId == id);
                    result = await _unitOfWork.GenericRepository<MasterPermisson>().DeleteRageItems("DELETE FROM [dbo].[MasterPermisson] WHERE Id = @Id", msPRMS.ToArray());
                    if (!result)
                        throw new Exception("Delete permission failed");
                    break;
                    #endregion                    
            }

            var getModel = await _unitOfWork.GenericRepository<T>().Get(id);
            if (getModel == null)
                throw new DataNotFoundException("Data not found");

            result = await _unitOfWork.GenericRepository<T>().Delete(getModel);
            if (!result)
                throw new Exception("Delete failed");
            return result;

        }

        public async Task<MasterPermisson> GetPermissionByUserId(int PositionID, int MenuID)
        {
            var obj = await _unitOfWork.GenericRepository<MasterPermisson>().GetAll();
            var result = obj.Where(w => w.PositionId == PositionID && w.MenuId == MenuID).FirstOrDefault();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterContactType>> GetAllContactType()
        {
            var result = await _unitOfWork.GenericRepository<MasterContactType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterBussinessType>> GetAllBussinessType()
        {
            var result = await _unitOfWork.GenericRepository<MasterBussinessType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterReasonDecInc>> GetAllReasonDecInc()
        {
            var result = await _unitOfWork.GenericRepository<MasterReasonDecInc>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<DocumentType>> GetAllDocumentTypes()
        {
            var result = await _unitOfWork.GenericRepository<DocumentType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterVatType>> GetAllVattype()
        {
            var result = await _unitOfWork.GenericRepository<MasterVatType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterVatRate>> GetAllVatRate()
        {
            var result = await _unitOfWork.GenericRepository<MasterVatRate>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterTagDetails>> GetAllTagList()
        {
            var result = await _unitOfWork.GenericRepository<MasterTagDetails>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterTagStatus>> GetAllTagStatus()
        {
            var result = await _unitOfWork.GenericRepository<MasterTagStatus>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterPayChqType>> GetAllChequeType()
        {
            var result = await _unitOfWork.GenericRepository<MasterPayChqType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterBank>> GetAllBank()
        {
            var result = await _unitOfWork.GenericRepository<MasterBank>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterCreditCard>> GetAllCreditCard(int bankId)
        {
            var result = await _unitOfWork.GenericRepository<MasterCreditCard>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.BankId == bankId);
        }

        public async Task<IEnumerable<MasterCardUseType>> GetAllCreditCardSwipe()
        {
            var result = await _unitOfWork.GenericRepository<MasterCardUseType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterPosition>> GetAllPosition()
        {
            var result = await _unitOfWork.GenericRepository<MasterPosition>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterPrefix>> GetAllPrefixName()
        {
            var result = await _unitOfWork.GenericRepository<MasterPrefix>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterNextService>> GetAllNextService()
        {
            var result = await _unitOfWork.GenericRepository<MasterNextService>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterNextServiceSub>> GetAllSubNextService(int nextserviceId)
        {
            var result = await _unitOfWork.GenericRepository<MasterNextServiceSub>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.NextServiceId == nextserviceId);
        }

        public async Task<IEnumerable<MasterProvince>> GetAllProvince()
        {
            var result = await _unitOfWork.GenericRepository<MasterProvince>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterDistrict>> GetAllDistrictByProvinceId(int provinceId)
        {
            var result = await _unitOfWork.GenericRepository<MasterDistrict>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.ProvinceId == provinceId);
        }

        public async Task<IEnumerable<MasterSubDistrict>> GetAllSubDistrictByProvinceId(int provinceId, int districtId)
        {
            var result = await _unitOfWork.GenericRepository<MasterSubDistrict>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.ProvinceId == provinceId && w.DistrictId == districtId);
        }

        public async Task<IEnumerable<MasterDot>> GetAllDot()
        {
            var result = await _unitOfWork.GenericRepository<MasterDot>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterCarType>> GetAllCarType()
        {
            var result = await _unitOfWork.GenericRepository<MasterCarType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterCarBrand>> GetAllCarBrand()
        {
            var result = await _unitOfWork.GenericRepository<MasterCarBrand>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterCarModel>> GetAllCarModel()
        {
            var result = await _unitOfWork.GenericRepository<MasterCarModel>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterCarBrand>> GetAllCarBrandByCarTypeId(int cartypeId)
        {
            var result = await _unitOfWork.GenericRepository<MasterCarBrand>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.CarTypeId == cartypeId);
        }

        public async Task<IEnumerable<MasterCarModel>> GetAllCarModelByCarBrandId(int carbrandId)
        {
            var result = await _unitOfWork.GenericRepository<MasterCarModel>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.CarBrandId == carbrandId);
        }

        public async Task<IEnumerable<MasterCarSubModel>> GetAllCarSubModelByCarModelId(int carmodelId)
        {
            var result = await _unitOfWork.GenericRepository<MasterCarSubModel>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.CarModelId == carmodelId);
        }

        public async Task<IEnumerable<MasterCarGear>> GetAllCarGear()
        {
            var result = await _unitOfWork.GenericRepository<MasterCarGear>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterProGroup>> GetAllProductGroups()
        {
            var result = await _unitOfWork.GenericRepository<MasterProGroup>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterProType>> GetAllProductTypes()
        {
            var result = await _unitOfWork.GenericRepository<MasterProType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterProBrand>> GetAllProductBrands()
        {
            var result = await _unitOfWork.GenericRepository<MasterProBrand>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterProSize>> GetAllProductSize()
        {
            var result = await _unitOfWork.GenericRepository<MasterProSize>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterProType>> GetAllProductTypeByProGroupId(int progroupId)
        {
            var result = await _unitOfWork.GenericRepository<MasterProType>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.ProGroupId == progroupId);
        }

        public async Task<IEnumerable<MasterProBrand>> GetAllProductBrandByProTypeId(int protypeId)
        {
            var result = await _unitOfWork.GenericRepository<MasterProBrand>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.ProTypeId == protypeId);
        }

        public async Task<IEnumerable<MasterPromodel>> GetAllProductModelByProBrandId(int probrandId)
        {
            var result = await _unitOfWork.GenericRepository<MasterPromodel>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result.Where(w => w.ProBrandId == probrandId);
        }

        public async Task<IEnumerable<MasterLocation>> GetAllProductLocation()
        {
            var result = await _unitOfWork.GenericRepository<MasterLocation>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        public async Task<IEnumerable<MasterProUnit>> GetAllProUnit()
        {
            var result = await _unitOfWork.GenericRepository<MasterProUnit>().GetAll();
            if (result == null)
                throw new DataNotFoundException("Data not found");

            return result;
        }

        private  string GenerateContactTypeCode()
        {
            string code = null;
            if (_unitOfWork.GenericRepository<MasterContactType>().GetAll().Result.OrderByDescending(ct => ct.Id).FirstOrDefault() == null)
                code = "1";
            else 
                code = _unitOfWork.GenericRepository<MasterContactType>().GetAll().Result.OrderByDescending(ct => ct.Id).FirstOrDefault().Code;
            
            return String.Format("{0:D2}", Convert.ToInt64(code) + 1); ;
        }
    }
}
