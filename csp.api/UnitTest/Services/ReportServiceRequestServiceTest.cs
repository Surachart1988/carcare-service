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
    public class ReportServiceRequestServiceTest
    {

        [Fact]
        public async void SearchReportServiceRequestByFieldTest()
        {
            IEnumerable<Sale> sale = new List<Sale>() { new Sale() { Id = 1, Code = "test1" } };

            Mock<IReportServiceRequestRepository> repositorMock = new Mock<IReportServiceRequestRepository>();
            repositorMock.Setup(r => r.SearchReportServiceRequestByField(
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<bool>()
                )
            ).Returns(Task.FromResult(sale));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ReportServiceRequestRepository).Returns(repositorMock.Object);


            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var service = new ReportServiceRequestService(mockUnitOfWork.Object);
            var result = await service.SearchReportServiceRequestByField(searchParams);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetTotalSearchReportServiceRequestByFieldTest()
        {
            IEnumerable<Sale> sale = new List<Sale>() { new Sale() { Id = 1, Code = "test1" } };

            Mock<IReportServiceRequestRepository> repositorMock = new Mock<IReportServiceRequestRepository>();
            repositorMock.Setup(r => r.GetTotalSearchReportServiceRequestByField(
                It.IsAny<Dictionary<string, string>>()
                )
            ).Returns(Task.FromResult(1));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ReportServiceRequestRepository).Returns(repositorMock.Object);


            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var service = new ReportServiceRequestService(mockUnitOfWork.Object);
            var result = await service.GetTotalSearchReportServiceRequestByField(searchParams);

            Assert.Equal(1, result);
        }
    }
}
