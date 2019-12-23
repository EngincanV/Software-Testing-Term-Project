using Moq;
using NUnit.Framework;
using QuestionAnswer.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class UnitTests
    {
        UserOperations operations = new UserOperations();
        public readonly IUserRepository _repository;

        public UnitTests()
        {
            //mocking get all method
            var userList = new List<User>
            {
                new User { Id = 1, Username = "Student1", Password = "Student1" },
                new User { Id = 2, Username = "Teacher1", Password = "Teacher1" }
            };

            //mock the user repository using Moq
            var mockUserRepository = new Mock<IUserRepository>();

            //setup method for get all method
            mockUserRepository.Setup(mr => mr.GetAll()).Returns(userList);

            //setup method for add method
            mockUserRepository.Setup(mr => mr.Add(It.IsAny<User>())).Callback(
                (User user) =>
                {
                    userList.Add(user);
                });

            //setup method for update method
            mockUserRepository.Setup(mr => mr.Update(It.IsAny<User>())).Callback(
                (User user) =>
                {
                    var originalUser = userList.Where(q => q.Id == user.Id).Single();

                    if (originalUser == null)
                        throw new InvalidOperationException();

                    originalUser.Username = user.Username;
                    originalUser.Password = user.Password;
                });

            this._repository = mockUserRepository.Object;
        }

        [Test]
        public void Login()
        {
            var isUserExist = operations.IsUserExist("Teacher", "Teacher");

            if (isUserExist)
                Assert.Pass("User exist");

            else
                Assert.Fail("User is not exist");
        }

        [Test]
        public void AddUser()
        {
            var actual = this._repository.GetAll().Count + 1;
            var user = new User { Id = 3, Username = "Admin", Password = "Admin" };

            this._repository.Add(user);
            var expectedUserCount = this._repository.GetAll().Count;

            Assert.AreEqual(actual, expectedUserCount);
        }

        [Test]
        public void UpdateUser()
        {
            var user = new User { Id = 2, Username = "Student2", Password = "Student2" };
            this._repository.Update(user);

            var expected = this._repository
                .GetAll().FirstOrDefault(p => p.Id == user.Id);

            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Username, user.Username);
            Assert.AreEqual(expected.Password, user.Password);
        }
    }
}