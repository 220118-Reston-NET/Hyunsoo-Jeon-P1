using System.Collections.Generic;
using Models;
using Moq;
using DL;
using BL;
using Xunit;

namespace Test
{
    public class CustomerBLTest
    {
        [Fact]

        public void Should_Get_ALL_Customer()
        {   
            //arrange
            string customerName = "John Doe";
            string email = "john@email.com";
            string address = "1992 Main st, Los gatos, CA 98888";

            Customer customer = new Customer(){
                Name = customerName,
                Email = email,
                Address = address
            };

            List<Customer> expectedListOfCustomer = new List<Customer>();
            expectedListOfCustomer.Add(customer);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            ICustomerBL customerBL = new CustomerBL(mockRepo.Object);

            // act
            List<Customer> acualListOfCustomer = customerBL.GetAllCustomer();

            // assert
            Assert.Same(expectedListOfCustomer, acualListOfCustomer);
            Assert.Equal(customerName, acualListOfCustomer[0].Name);
            Assert.Equal(email, acualListOfCustomer[0].Email);
            Assert.Equal(address, acualListOfCustomer[0].Address);

        }
    }
}