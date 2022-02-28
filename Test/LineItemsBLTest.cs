// using System.Collections.Generic;
// using Models;
// using Moq;
// using DL;
// using BL;
// using Xunit;

// namespace Test
// {
//     public class LineItemsBLTest
//     {
//         [Fact]

//         public void Should_Get_ALL_LineItems()
//         {
//             //arrange
//             int productId = 1;
//             int orderId = 1;
//             string productName = "Coolant";
//             decimal price = 10;
//             int qty = 40;

//             LineItems lineItems = new LineItems()
//             {
//                 ProductID = productId,
//                 OrderId = orderId,
//                 ProductName = productName,

//             };

//             List<Customer> expectedListOfCustomer = new List<Customer>();
//             expectedListOfCustomer.Add(customer);

//             Mock<IRepository> mockRepo = new Mock<IRepository>();

//             mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

//             ICustomerBL customerBL = new CustomerBL(mockRepo.Object);

//             // act
//             List<Customer> acualListOfCustomer = customerBL.GetAllCustomer();

//             // assert
//             Assert.Same(expectedListOfCustomer, acualListOfCustomer);
//             Assert.Equal(customerName, acualListOfCustomer[0].Name);
//             Assert.Equal(email, acualListOfCustomer[0].Email);
//             Assert.Equal(address, acualListOfCustomer[0].Address);

//         }
//     }
// }