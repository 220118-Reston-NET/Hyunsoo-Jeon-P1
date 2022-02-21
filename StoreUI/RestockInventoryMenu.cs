using Models;
using BL;

namespace StoreUI
{
    public class RestockInventoryMenu : IMenu
    {
        private List<Inventory> _listOfInventory;
        public static int _inventoryId;

        private IInventoryBL _inventoryBL;
        public RestockInventoryMenu(IInventoryBL p_inventoryBL)
        {
            _inventoryBL = p_inventoryBL;
            _listOfInventory = _inventoryBL.GetAllInventory();
        }

        public void Current_inventory_Display()
        {
            foreach(var item in _listOfInventory)
            {
                Console.WriteLine(item);
            }
        }
        public void Display()
        {
            Current_inventory_Display();
            Console.WriteLine("[1] Enter the Inventory ID to restock");
            Console.WriteLine("[0] Exit");
        }


        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "AdminAddMenu";
                case "1":
                    Log.Information("User enter the inventory ID to precess restock \n" + _inventoryId);

                    Console.WriteLine("Enter Inventory ID");
                    _inventoryId= Convert.ToInt32(Console.ReadLine());

                    while (_listOfInventory.All(p => p.InventoryID != _inventoryId))
                    {
                        Console.WriteLine("You Id is not vaildate! Try again!");
                        _inventoryId = Convert.ToInt32(Console.ReadLine());

                    }
                    return "RestockInventoryDetail";
                default:
                    Console.WriteLine("Plese input a valid response");
                    Console.WriteLine("Plese press enter to continue");
                    Console.ReadLine();
                    return "AdminAddMenu";
            }
        }
    }
}