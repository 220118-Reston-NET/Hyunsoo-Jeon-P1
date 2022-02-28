using System.Collections.Generic;
using Models;
using Moq;
using DL;
using BL;
using Xunit;

namespace Test
{
    public class UserBLTest
    {
        [Fact]

        public void Should_Get_ALL_User()
        {
            //arrange
            int userID = 1;
            string userName = "John Doe";
            string password = "1234";

            User user = new User()
            {
                UserID = userID,
                UserName = userName,
                Password = password
            };

            List<User> expectedListOfUser = new List<User>();
            expectedListOfUser.Add(user);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllUsers()).Returns(expectedListOfUser);

            IUserBL userBL = new UserBL(mockRepo.Object);

            // act
            List<User> acualListOfUser = userBL.GetAllUsers();

            // assert
            Assert.Same(expectedListOfUser, acualListOfUser);
            Assert.Equal(userID, acualListOfUser[0].UserID);
            Assert.Equal(userName, acualListOfUser[0].UserName);
            Assert.Equal(password, acualListOfUser[0].Password);

        }
    }
}