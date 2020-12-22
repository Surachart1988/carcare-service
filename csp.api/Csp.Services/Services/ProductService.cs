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
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //_cache = cache;
        }

        public async Task<int> GetTotalCountSearchProductByField(Dictionary<string, string> searchParams)
        {
            return await _unitOfWork.ProductRepository.GetTotalSrchProductByField(searchParams);
        }

        public async Task<IEnumerable<Product>> SearchProductByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return await _unitOfWork.ProductRepository.SearchProductByField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }

        //public async Task<(IEnumerable<object> Resources, int ToTalRecords)> GetAllProductSalePrice(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        //{
        //    return await _unitOfWork.ProductRepository.SearchProductSalePriceByField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        //}

        //public async Task<(IEnumerable<object> Resources, int ToTalRecords)> GetAllProductForSaleProcess(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        //{
        //    return await _unitOfWork.ProductRepository.SearchProductForSaleProcessByField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        //}

        public async Task<Product> Create(Product model, decimal produtceSalePrices)
        {
            if (_unitOfWork.ProductRepository.SearchByField(new Dictionary<string, string> { { "Code", model.Code } }).Result.Any())
                throw new DataDuplicateException($"Product Code {model.Code} already exists");

            if (_unitOfWork.ProductRepository.SearchByField(new Dictionary<string, string> { { "NameTh", model.NameTh } }).Result.Any())
                throw new DataDuplicateException($"Product Name {model.NameTh} already exists");

            if (model.Status == 2)
            {
                model.CancelAt = DateTime.Now;
                model.CancelBy = UserId;
            }

            model.Code = GenerateCode(model.ProGroupId, (int)model.ProTypeId, (int)model.ProBrandId); ;

            var result = await _unitOfWork.ProductRepository.Add(model);
            if (result == null)
                throw new Exception("Insert data failed");


            var prductSalPric = await _unitOfWork.ProductSalePriceRepository.Add(
                new ProductSalePrice { 
                    ProductId = result.Id,
                    PriceDate = result.CreatedAt.Value,
                    NPriceDate = result.CreatedAt.Value.ToString("yyyy-MM-dd"),
                    Price = produtceSalePrices
                });

            //result.ProductSalePrice = model.ProductSalePrice.Select(s =>
            //{
            //    s.ProductId = result.Id;
            //    s.PriceDate = result.CreatedAt.Value;
            //    s.NPriceDate = result.CreatedAt.Value.ToString("yyyy-MM-dd");
            //    return s;
            //}).ToList();

                //var resultProprice = await _unitOfWork.GenericRepository<ProductSalePrice>().AddRageItems(@"INSERT INTO [dbo].[ProductSalePrice]
                //                                                                                           ([ProductID]
                //                                                                                           ,[PriceDate]
                //                                                                                           ,[nPriceDate]
                //                                                                                           ,[Price]
                //                                                                                           ,[CreatedAt]
                //                                                                                           ,[UpdatedAt]
                //                                                                                           ,[CreatedBy]
                //                                                                                           ,[UpdatedBy])
                //                                                                                     VALUES
                //                                                                                           (@ProductID
                //                                                                                           ,@PriceDate
                //                                                                                           ,@nPriceDate
                //                                                                                           ,@Price
                //                                                                                           ,@CreatedAt
                //                                                                                           ,@UpdatedAt
                //                                                                                           ,@CreatedBy
                //                                                                                           ,@UpdatedBy)", result.ProductSalePrice);
            return result;
        }

        public async Task<(Product, decimal)> GetProductById(int id)
        {
            var product = await _unitOfWork.ProductRepository.Get(id);
            if (product == null)
                throw new DataNotFoundException("Data not found");

            // get productsaleprice for parse 1
            var searchParams = new Dictionary<string, string>() { { "ProductID", product.Id.ToString() } };
            var salepriceList = (await _unitOfWork.ProductSalePriceRepository.SearchByField(searchParams)).FirstOrDefault();

            return (product, salepriceList.Price);
        }

        public async Task<bool> Update(Product model, decimal produtceSalePrices)
        {
            var product = await _unitOfWork.ProductRepository.Get(model.Id);

            if (product == null)
                throw new DataNotFoundException("Data not found");

            if (product.BuyUnitId != model.BuyUnitId || product.SaleUnitId != model.SaleUnitId)
                if (_unitOfWork.GenericRepository<SaleDetail>().GetAll().Result.Where(w => w.ProductId == model.Id).Any())
                    throw new NotAccpteableException("product can not modify");

            if (model.Status == 2)
            {
                model.CancelAt = DateTime.Now;
                model.CancelBy = UserId;
            }
            else if (model.Status == 1 && product.Status == 2)
            {
                model.CancelAt = null;
                model.CancelBy = null;
            }
            var result = await _unitOfWork.ProductRepository.Update(model);
            if (!result)
                throw new Exception("Update failed");

            var searchParams = new Dictionary<string, string>() { { "ProductID", product.Id.ToString() } };

            var prductSalPric = (await _unitOfWork.ProductSalePriceRepository.SearchByField(searchParams)).FirstOrDefault();
            prductSalPric.ProductId = product.Id;
            prductSalPric.PriceDate = product.CreatedAt.Value;
            prductSalPric.NPriceDate = product.CreatedAt.Value.ToString("yyyy-MM-dd");
            prductSalPric.Price = produtceSalePrices;

            result = await _unitOfWork.ProductSalePriceRepository.Update(prductSalPric);

            //var prductSalPric = await _unitOfWork.ProductSalePriceRepository.Update(
            //                                        new ProductSalePrice
            //                                        {
            //                                            ProductId = result.Id,
            //                                            PriceDate = result.CreatedAt.Value,
            //                                            NPriceDate = result.CreatedAt.Value.ToString("yyyy-MM-dd"),
            //                                            Price = produtceSalePrices
            //                                        });


            //var resultProprice = await _unitOfWork.GenericRepository<ProductSalePrice>().UpdateRageItems(@"UPDATE [dbo].[ProductSalePrice]
            //                                                                                               SET [ProductID] = @ProductID
            //                                                                                                  ,[PriceDate] = @PriceDate
            //                                                                                                  ,[nPriceDate] = @nPriceDate
            //                                                                                                  ,[Price] = @Price
            //                                                                                                  ,[CreatedAt] = @CreatedAt
            //                                                                                                  ,[UpdatedAt] = @UpdatedAt
            //                                                                                                  ,[CreatedBy] = @CreatedBy
            //                                                                                                  ,[UpdatedBy] = @UpdatedBy
            //                                                                                                  WHERE Id = @Id",
            //                                                                                             model.ProductSalePrice);
            return result;
        }

        private string GenerateCode(int progroupId, int protypeId, int probrandId)
        {
            Product product;
            string code = "1";

            var productList = _unitOfWork.ProductRepository.GetAll().Result;

            if (probrandId > 0)
                product = productList.Where(w => w.ProBrandId == probrandId && w.ProTypeId == protypeId && w.ProGroupId == progroupId)
                              .OrderByDescending(o => o.Id).FirstOrDefault();
            else
                product = productList.Where(w => w.ProBrandId == null && w.ProTypeId == protypeId && w.ProGroupId == progroupId)
                              .OrderByDescending(o => o.Id).FirstOrDefault();

            if (product != null)
            {
                code = $"{Convert.ToInt64(product.Code) + 1}";
            }
            else
            {
                var _newSerires = $"{progroupId}{protypeId}{probrandId}";
                var _newSku = String.Format("{0:D5}", Convert.ToInt64(code));
                code = $"{_newSerires}{_newSku}";
            }

            return code;
        }
    }
}
