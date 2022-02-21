using System.Collections.Generic;
using Models;
using Moq;
using DL;
using BL;
using Xunit;

namespace Test
{
    public class ProductBLTest
    {
        [Fact]

        public void Should_Get_ALL_Product()
        {   
            //arrange
            string productName = "Cabin filter";
            int price = 35;

            Product product = new Product(){
                ProductName = productName,
                Price = price
            };

            List<Product> expectedListOfProduct = new List<Product>();
            expectedListOfProduct.Add(product);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllProduct()).Returns(expectedListOfProduct);

            IProductBL productBL = new ProductBL(mockRepo.Object);

            // act
            List<Product> acualListOfProduct = productBL.GetAllProdct();

            // assert
            Assert.Same(expectedListOfProduct, acualListOfProduct);
            Assert.Equal(productName, expectedListOfProduct[0].ProductName);
            Assert.Equal(price, expectedListOfProduct[0].Price);


        }
    }
}