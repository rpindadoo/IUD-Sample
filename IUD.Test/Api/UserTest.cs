using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using IUD.Api.Controllers;
using IUD.DataAccess.Entities;
using IUD.Service.EntityServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IUD.Test.Api
{
    [TestClass]
    public class TestUsers
    {
        private readonly Mock<IUserService> _mockUserService = new Mock<IUserService>();

        [TestInitialize]
        public void Setup()
        {
            AutomapperConfig();
        }


        [TestMethod]
        public async Task GetAllUsersAsync_ShouldReturnAllUsers()
        {
            List<IUD.Api.Models.User> testUsersApi = GetTestUsersApi();
            var testUsersDb = GetTestUsersDb();
            _mockUserService.Setup(r => r.GetAll()).Returns(testUsersDb.AsQueryable);
            var controller = new UserController(_mockUserService.Object);

            var result = await controller.GetAll() as OkNegotiatedContentResult<IEnumerable<IUD.Api.Models.User>>;
            Assert.AreEqual(testUsersApi.Count, result.Content.Count());
        }

        [TestMethod]
        public async Task GetUser_ShouldReturnCorrectUser()
        {
            const int id = 1;
            var testUsersDb = GetTestUsersDb();
            User userdb = testUsersDb.FirstOrDefault(x => x.Id == id);
            _mockUserService.Setup(r => r.GetById(1)).Returns(userdb);
            var controller = new UserController(_mockUserService.Object);
            var result = await controller.Get(id) as OkNegotiatedContentResult<IUD.Api.Models.User>;
            Assert.AreEqual(userdb.Name, result.Content.Name);
        }

        [TestMethod]
        public async Task GetUser_ShouldNotFindUser()
        {
            var controller = new UserController(_mockUserService.Object);
            IHttpActionResult result = await controller.Get(999);
            Assert.IsInstanceOfType(result, typeof (NotFoundResult));
        }


        [TestMethod]
        public async Task CreateUser_ReturnsAnOkResultWithTheCreatedUser()
        {
            var controller = new UserController(_mockUserService.Object);
            var newEmptyUser = new IUD.Api.Models.User();
            IHttpActionResult result = await controller.Create(newEmptyUser);
            Assert.IsInstanceOfType(result, typeof (OkNegotiatedContentResult<IUD.Api.Models.User>));
        }

        [TestMethod]
        public async Task UpdateUser_ReturnsAnOkResultWithAUser()
        {
            var userDb = new User {Id = 20, Name = "John", Birthdate = DateTime.Now};
            var userModel = new IUD.Api.Models.User {Id = 20, Name = "John", Birthdate = DateTime.Now};

            _mockUserService.Setup(r => r.Update(userDb)).Returns(true);
            var controller = new UserController(_mockUserService.Object);
            IHttpActionResult result = await controller.Update(userModel);
            Assert.IsInstanceOfType(result, typeof (OkNegotiatedContentResult<IUD.Api.Models.User>));
        }

        [TestMethod]
        public async Task RemoveUser_ReturnsAnOkResul()
        {
            _mockUserService.Setup(r => r.GetById(0)).Returns(new User());
            var controller = new UserController(_mockUserService.Object);
            IHttpActionResult result = await controller.Remove(0);
            Assert.IsInstanceOfType(result, typeof (OkResult));
        }

        #region setup private methods

        private IEnumerable<User> GetTestUsersDb()
        {
            var testUsers = new List<User>
            {
                new User {Id = 1, Name = "John", Birthdate = DateTime.Now},
                new User {Id = 2, Name = "Bob", Birthdate = DateTime.Now}
            };

            return testUsers;
        }

        private List<IUD.Api.Models.User> GetTestUsersApi()
        {
            var testUsers = new List<IUD.Api.Models.User>
            {
                new IUD.Api.Models.User {Id = 1, Name = "John", Birthdate = DateTime.Now},
                new IUD.Api.Models.User {Id = 2, Name = "Bob", Birthdate = DateTime.Now}
            };

            return testUsers;
        }

        private static void AutomapperConfig()
        {
            Mapper.CreateMap<User, IUD.Api.Models.User>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(m => m.Name))
                .ForMember(dest => dest.Birthdate, src => src.MapFrom(m => m.Birthdate));

            Mapper.CreateMap<IUD.Api.Models.User, User>().ReverseMap();
            Mapper.AssertConfigurationIsValid();
        }

        #endregion
    }
}