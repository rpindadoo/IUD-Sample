using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUD.DataAccess.Entities;
using IUD.Service.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IUD.Test.Application
{
     [TestClass]
    public class UserServiceTest
    {
        private Mock<IService<User>> _userService;

        [TestInitialize]
        public void SetUp()
        {
            _userService = new Mock<IService<User>>();
            _userService.Setup(x => x.GetAll()).Returns(TestUsers.AsQueryable());
        }

         [TestMethod]
        public void get_all_returns_all()
        {
            var result = _userService.Object.GetAll();
            Assert.AreEqual(TestUsers.Count(), result.Count());
        }

         private static IEnumerable<User> TestUsers
         {
             get
             {
                 return new List<User>()
                 {
                     new User {Id = 1, Name = "John", Birthdate = DateTime.Now}, 
                     new User {Id = 2, Name = "Bob", Birthdate = DateTime.Now}
                 };
             }
         }
    }
}
