using Xunit;
using Models;

namespace Test
{
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

        [Fact]
        public void CustomerAddressShouldValidData()
        {
            //arrange
            Customer address = new Customer();
            string validAddress = "1234 main st, san jose, ca 99999";

            //act
            address.Address = validAddress;

            // assert
            Assert.NotNull(address.Address);
            Assert.Equal(validAddress, address.Address);

        }
        [Fact]
        public void CustomerIDShouldValidData()
        {
            //arrange
            Customer id = new Customer();
            int validID = 1;

            //act
            id.CustomerID = validID;

            // assert
            Assert.NotNull(id.CustomerID);
            Assert.Equal(validID, id.CustomerID);
        }
            [Fact]
            public void CustomerEmailShouldValidData()
            {
                //arrange
                Customer email = new Customer();
                string validEmail = "vaild@email.com";

                //act
                email.Email = validEmail;

                // assert
                Assert.NotNull(email.Email);
                Assert.Equal(validEmail, email.Email);

            }
        [Fact]
        public void CustomerContactNoShouldValidData()
        {
            //arrange
            Customer contactNo = new Customer();
            string validContactNo = "111-222-1111";

            //act
            contactNo.ContactNo = validContactNo;

            // assert
            Assert.NotNull(contactNo.ContactNo);
            Assert.Equal(validContactNo, contactNo.ContactNo);
        }
        }


    public class InventoryModelTest
    {
        [Fact]
        public void InventoryStoreIDShouldValidData()
        {
            Inventory storeId = new Inventory();
            int validId = 1;

            storeId.StoreID = validId;

            Assert.NotNull(storeId.StoreID);
            Assert.Equal(validId, storeId.StoreID);
        }

        [Fact]
        public void InventoryQuantityShouldValidData()
        {
            Inventory qty = new Inventory();
            int validQty = 40;

            qty.Qty = validQty;

            Assert.NotNull(qty.Qty);
            Assert.Equal(validQty, qty.Qty);
        }
    }




    public class LineItemModelTest
    {
        [Fact]
        public void LineItemProductNameShouldValidData()
        {
            LineItems productName = new LineItems();
            string validName = "brake fluid";

            productName.ProductName = validName;

            Assert.NotNull(productName.ProductName);
            Assert.Equal(validName, productName.ProductName);
        }
        
        [Fact]
        public void LineItemQuantityShouldValidData()
        {
            LineItems qty = new LineItems();
            int validQty = 3;

            qty.Qty = validQty;

            Assert.NotNull(qty.Qty);
            Assert.Equal(validQty, qty.Qty);
        }
    }

    public class StoreFrontModelTest
    {
        [Fact]
        public void StoreFronStoreNameShouldValidData()
        {
            StoreFront storeName = new StoreFront();
            string validName = "Car parts shop 4";

            storeName.StoreName = validName;

            Assert.NotNull(storeName.StoreName);
            Assert.Equal(validName, storeName.StoreName);
        }

        [Fact]
        public void StoreFronStoreAddressShouldValidData()
        {
            StoreFront storeAddress = new StoreFront();
            string validAddress = "1212 Sunset ave, San Jose, CA 99999";

            storeAddress.StoreAddress = validAddress;

            Assert.NotNull(storeAddress.StoreAddress);
            Assert.Equal(validAddress, storeAddress.StoreAddress);
        }
    }

    public class UserModelTest
    {
        [Fact]
        public void UserNameShouldvalidData()
        {
            User userName = new User();
            string validName = "jordan";

            userName.UserName = validName;

            Assert.NotNull(userName.UserName);
            Assert.Equal(validName, userName.UserName);
        }
        [Fact]
        public void PasswordShouldvalidData()
        {
            User password = new User();
            string validPassword = "1234";

            password.Password = validPassword;

            Assert.NotNull(password.Password);
            Assert.Equal(validPassword, password.Password);
        }

        public void UserIdShouldvalidData()
        {
            User userId = new User();
            int validUserId = 1;

            userId.UserID = validUserId;

            Assert.NotNull(userId.UserID);
            Assert.Equal(validUserId, userId.UserID);
        }
    }
    public class ProductModelTest
    {
        [Fact]
        public void ProducteNameShouldValidData()
        {
            Product productName = new Product();
            string validName = "Coolant";

            productName.ProductName = validName;

            Assert.NotNull(productName.ProductName);
            Assert.Equal(validName, productName.ProductName);
        }
    }

    }
