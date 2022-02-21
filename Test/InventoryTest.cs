using System.Collections.Generic;
using Models;
using Moq;
using DL;
using BL;
using Xunit;

namespace Test
{
    public class InventoryBLTest
    {
        [Fact]

        public void Should_Get_ALL_Inventory()
        {
            //arrange
            int inventoryID = 1;
            int storeID = 2;
            int productID = 1;
            int qty = 6;

            Inventory inventory = new Inventory()
            {
                InventoryID = inventoryID,
                StoreID = storeID,
                ProductID = productID,
                Qty = qty
            };

            List<Inventory> expectedListOfInventory = new List<Inventory>();
            expectedListOfInventory.Add(inventory);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllInventory()).Returns(expectedListOfInventory);

            IInventoryBL inventoryBL = new InventoryBL(mockRepo.Object);

            // act
            List<Inventory> acualListOfInventory = inventoryBL.GetAllInventory();

            // assert
            Assert.Same(expectedListOfInventory, acualListOfInventory);
            Assert.Equal(inventoryID, acualListOfInventory[0].InventoryID);
            Assert.Equal(storeID, acualListOfInventory[0].StoreID);
            Assert.Equal(productID, acualListOfInventory[0].ProductID);
            Assert.Equal(qty, acualListOfInventory[0].Qty);

        }
    }
}