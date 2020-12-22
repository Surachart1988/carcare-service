using Csp.DAL.Models;
using Csp.DAL.Repositories;
using Csp.DAL.UnitOfWork;
using Csp.Services.CustomeException;
using Csp.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Services
{
    public class BranchServiceTest
    {
        [Fact]
        public async void GetBranchTest()
        {
            Mock<IGenericRepository<Branch>> repositorMock = new Mock<IGenericRepository<Branch>>();
            repositorMock.Setup(r => r.Get(It.IsAny<int>())).Returns(Task.FromResult(new Branch() { Id = 1 }));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.GenericRepository<Branch>()).Returns(repositorMock.Object);

            var service = new BranchService(mockUnitOfWork.Object);
            Assert.NotNull(await service.GetBranch());
        }

        [Fact]
        public async void UpdateBranchTest()
        {
            var branch = new Branch() { Id = 1 };

            Mock<IGenericRepository<Branch>> repositorMock = new Mock<IGenericRepository<Branch>>();
            repositorMock.Setup(r => r.Update(It.IsAny<Branch>())).Returns(Task.FromResult(true));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.GenericRepository<Branch>()).Returns(repositorMock.Object);

            var service = new BranchService(mockUnitOfWork.Object);
            var result = await service.UpdateBranch(branch);

            Assert.True(result);
        }


    }
}
