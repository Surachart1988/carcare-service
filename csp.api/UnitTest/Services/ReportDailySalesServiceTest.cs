using Csp.DAL.Models;
using Csp.DAL.Repositories;
using Csp.DAL.UnitOfWork;
using Csp.Services.CustomeException;
using Csp.Services.Services;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Services
{
    public class ReportDailySalesServiceTest
    {

        [Fact]
        public async void SearchReportDailySalesByFieldTest()
        {
            IEnumerable<Sale> sale = new List<Sale>() { new Sale() { Id = 1, Code = "test1" } };

            Mock<IReportDailySalesRepository> repositorMock = new Mock<IReportDailySalesRepository>();
            repositorMock.Setup(r => r.SearchReportDailySalesByField(
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<bool>()
                )
            ).Returns(Task.FromResult(sale));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ReportDailySalesRepository).Returns(repositorMock.Object);


            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var service = new ReportDailySalesService(mockUnitOfWork.Object);
            var result = await service.SearchReportDailySalesByField(searchParams);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetTotalSearchReportDailySalesByFieldTest()
        {
            IEnumerable<Sale> sale = new List<Sale>() { new Sale() { Id = 1, Code = "test1" } };

            Mock<IReportDailySalesRepository> repositorMock = new Mock<IReportDailySalesRepository>();
            repositorMock.Setup(r => r.GetTotalSearchReportDailySalesByField(
                It.IsAny<Dictionary<string, string>>()
                )
            ).Returns(Task.FromResult(1));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ReportDailySalesRepository).Returns(repositorMock.Object);


            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var service = new ReportDailySalesService(mockUnitOfWork.Object);
            var result = await service.GetTotalSearchReportDailySalesByField(searchParams);

            Assert.Equal(1, result);
        }
    }
}
