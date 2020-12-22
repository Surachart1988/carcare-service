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
    public class UserServiceTest
    {
        [Fact]
        public async void GetUserByIdTest()
        {
            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.Get(It.IsAny<int>())).Returns(Task.FromResult(new User() { Id = 1 }));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);

            var service = new UserService(mockUnitOfWork.Object);
            Assert.NotNull(await service.GetUserById(1));
        }

        [Fact]
        public async void GetUserByLoginNameTest()
        {
            IEnumerable<User> user = new List<User>() { new User() { Id = 1, LoginName = "test" } };

            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.SearchByField(
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<bool>()
                )
            ).Returns(Task.FromResult(user));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);

            var service = new UserService(mockUnitOfWork.Object);
            Assert.NotNull(await service.GetUserByLoginName("test"));
        }

        [Fact]
        public async void CreateUserTest()
        {
            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.Add(It.IsAny<User>())).Returns(Task.FromResult(new User() { Id = 1 }));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);

            var service = new UserService(mockUnitOfWork.Object);

            var ex = Assert.ThrowsAsync<BadParametersException>(() => service.Create(new User(), ""));
            Assert.Equal("Password is required", ex.Result.Message);
            Assert.NotNull(await service.Create(new User(), "password"));
        }

        [Fact]
        public void CreateUserDuplicateTest()
        {
            IEnumerable<User> user = new List<User>() { new User() { Id = 1 } };

            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.SearchByField(
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<bool>()
                )
            ).Returns(Task.FromResult(user));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);

            var service = new UserService(mockUnitOfWork.Object);

            var ex = Assert.ThrowsAsync<DataDuplicateException>(() => service.Create(new User() { LoginName = "test" }, "password"));
            Assert.Equal("LoginName test is already taken", ex.Result.Message);
        }

        [Fact]
        public async void SearchUserByFieldTest()
        {
            IEnumerable<User> user = new List<User>() { new User() { Id = 1, LoginName = "test1"} };

            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.SrchUsrByField(
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<bool>()
                )
            ).Returns(Task.FromResult(user));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);


            Dictionary<string, string> searchParams = new Dictionary<string, string>();

            var service = new UserService(mockUnitOfWork.Object);
            var result = await service.SrchUsrByField(searchParams);

            Assert.NotNull(result);
        }

        [Fact]
        public async void UpdateUserTest()
        {
            var user = new User() { Id = 1 };

            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.Update(It.IsAny<User>())).Returns(Task.FromResult(true));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);

            var service = new UserService(mockUnitOfWork.Object);
            var result = await service.Update(user);

            Assert.True(result);
        }

        [Fact]
        public async void DeleteUserTest()
        {
            var cx = DateTime.Now;

            var user = new User() { Id = 1 };

            Mock<IUserRepository> repositorMock = new Mock<IUserRepository>();
            repositorMock.Setup(r => r.Delete(It.IsAny<User>())).Returns(Task.FromResult(true));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(repositorMock.Object);

            var service = new UserService(mockUnitOfWork.Object);
            var result = await service.Delete(user.Id);

            Assert.True(result);
        }
    }
}
