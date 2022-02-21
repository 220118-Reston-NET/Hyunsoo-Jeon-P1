using System.Collections.Generic;
using Models;
using Moq;
using DL;
using BL;
using Xunit;

namespace Test
{
    public class StoreFrontBLTest
    {
        [Fact]

        public void Should_Get_ALL_StoreFront()
        {
            //arrange
            string storeName = "Auto parts3";
            string storeAddress = "3535 highstreet, Campbell, CA 99999";

            StoreFront storeFront = new StoreFront()
            {
                StoreName = storeName,
                StoreAddress = storeAddress
            };

            List<StoreFront> expectedListOfStoreFront = new List<StoreFront>();
            expectedListOfStoreFront.Add(storeFront);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllStoreFront()).Returns(expectedListOfStoreFront);

            IStoreFrontBL storeFrontBL = new StoreFrontBL(mockRepo.Object);

            // act
            List<StoreFront> acualListOfStoreFront = storeFrontBL.GetAllStoreFront();

            // assert
            Assert.Same(expectedListOfStoreFront, acualListOfStoreFront);
            Assert.Equal(storeName, expectedListOfStoreFront[0].StoreName);
            Assert.Equal(storeAddress, expectedListOfStoreFront[0].StoreAddress);
        }
    }
}