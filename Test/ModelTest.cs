using Xunit;
using Models;

namespace Test
{
    public class ProductModelTest
    {
        [Fact]
        public void PriceShouldValidData()
        {
            //arrange
            Product price = new Product();
            int validPrice = 100;

            //act
            price.Price = validPrice;

            // assert
            Assert.NotNull(price.Price);
            Assert.Equal(validPrice, price.Price);

        }

        [Theory]
        [InlineData(-9)]
        [InlineData(-100)]
        [InlineData(-500)]
        public void PriceShouldFailSetInvalidData(int p_invalidPrice)
        {
            // arrange
            Product price = new Product();

            // act & assert
            Assert.Throws<System.Exception>(
                () => price.Price = p_invalidPrice
            );
        }
    }
    public class CustomerModelTest
    {
        [Fact]
        public void CustomerNameShouldValidData()
        {
            //arrange
            Customer name = new Customer();
            string validName = "Jordan";

            //act
            name.Name = validName;

            // assert
            Assert.NotNull(name.Name);
            Assert.Equal(validName, name.Name);

        }
    }
    
}
