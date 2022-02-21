using Models;
using BL;

namespace StoreUI
{
    public class RestockInventoryDetailMenu : IMenu
    {
        private List<Inventory> _listOfInventory;
        public static int _inventoryId;

        private IInventoryBL _inventoryBL;
        public RestockInventoryDetailMenu(IInventoryBL p_inventoryBL)
        {
            _inventoryBL = p_inventoryBL;
            _listOfInventory = _inventoryBL.GetAllInventoryByID(RestockInventoryMenu._inventoryId);
        }

        public void Current_inventory_Display()
        {
            foreach (var item in _listOfInventory)
            {
                Console.WriteLine(item);
            }
        }
        public void Display()
        {
            Current_inventory_Display();
            Console.WriteLine("[1] Process to restock");
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

                    Console.WriteLine("Enter Quantity to restock");

                    int newQty = Convert.ToInt32(Console.ReadLine());
                    Log.Information("User enter the quantity to restock \n" + newQty);

                    _inventoryBL.ReplenishInventory(RestockInventoryMenu._inventoryId, newQty);
                    Console.WriteLine("Your restock is Success!");
                    Log.Information("Restock Success \n");

                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "RestockInventoryDetail";
                default:
                    Console.WriteLine("Plese input a valid response");
                    Console.WriteLine("Plese press enter to continue");
                    Console.ReadLine();
                    return "RestockInventoryDetail";
            }
        }
    }
}