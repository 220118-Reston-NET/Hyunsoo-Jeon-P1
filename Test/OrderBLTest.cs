using System.Collections.Generic;
using Models;
using Moq;
using DL;
using BL;
using Xunit;

namespace Test
{
    public class OrderBLTest
    {
        [Fact]

        public void Should_Get_ALL_Order()
        {
            //arrange
            int orderID = 1;
            int customerID = 2;
            int storeID = 1;
            int totalPrice = 6;


            Order order = new Order()
            {
                OrderID = orderID,
                CustomerID = customerID,
                StoreID= storeID,
                TotalPrice = totalPrice
            };

            List<Order> expectedListOfOrder = new List<Order>();
            expectedListOfOrder.Add(order);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllOrder()).Returns(expectedListOfOrder);

            IOrderBL orderBL = new OrderBL(mockRepo.Object);

            // act
            List<Order> acualListOfOrder = orderBL.GetAllOrder();

            // assert
            Assert.Same(expectedListOfOrder, acualListOfOrder);
            Assert.Equal(orderID, acualListOfOrder[0].OrderID);
            Assert.Equal(customerID, acualListOfOrder[0].CustomerID);
            Assert.Equal(storeID, acualListOfOrder[0].StoreID);
            Assert.Equal(totalPrice, acualListOfOrder[0].TotalPrice);

        }
    }
}