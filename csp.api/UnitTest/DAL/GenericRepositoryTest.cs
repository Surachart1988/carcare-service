using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using Csp.DAL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.DAL.Helper;
using Xunit;

namespace UnitTest.DAL
{
    public class GenericRepositoryTest
    {
        private InMemoryDatabase _db;
        GenericRepository<MasterPosition> _repo;

        public GenericRepositoryTest()
        {
            //Arrange
            var users = new List<MasterPosition>
            {
                new MasterPosition {Id=1, Name="test1", CreatedAt=DateTime.Now},
                new MasterPosition {Id=2, Name="test2", CreatedAt=DateTime.Now},
                new MasterPosition {Id=3, Name="test3", CreatedAt=DateTime.Now}
            };

            _db = new InMemoryDatabase();
            _db.Insert(users);

            var connectionFactoryMock = new Mock<IConnectionFactory>();
            connectionFactoryMock.Setup(c => c.GetConnection).Returns(_db.OpenConnection());

            _repo = new GenericRepository<MasterPosition>(connectionFactoryMock.Object, 1);
        }

        [Fact]
        public async void GetAllTest()
        {
            var result = await _repo.GetAll();
            Assert.Equal(3, result.Count()); ;
        }

        [Fact]
        public async void GetByIdTest()
        {
            var result = await _repo.Get(2);
            Assert.Equal(2, result.Id);
            Assert.NotEqual("test", result.Name);
            Assert.Equal("test2", result.Name);
        }

        // Dapper for sql server using SCOPE_IDENTITY that in memory database not support
        //[Fact]
        //public void InsertTest_WithDuplicationID()
        //{
        //    var ex = Assert.ThrowsAsync<Exception>(() => _repo.Add(new MasterPosition { Id = 1, Name = "test1" }));
        //}

        //[Fact]
        //public async void InsertTest_Success()
        //{
        //    var result = await _repo.Add(new MasterPosition { Id= 0, Name = "test4" });
        //    Assert.Equal(4, result.Id);
        //    Assert.Equal("test4", result.Name);
        //}

        [Fact]
        public async void UpdateTest()
        {
            var data = await _repo.Get(2);
            data.Name = "Updated";
            var result = await _repo.Update(data);
            Assert.True(result);

            data = await _repo.Get(2);
            Assert.Equal("Updated", data.Name);
            Assert.NotNull(data.CreatedAt);
        }

        [Fact]
        public async void DeleteTest()
        {
            var data = await _repo.Get(1);
            var result = await _repo.Delete(data);

            Assert.True(result);
            Assert.Equal(2, _repo.GetAll().Result.Count());
        }
    }
}
