using Models;
using BL;

namespace StoreUI
{
    public class AddInventoryMenu : IMenu
    {
        private static Inventory _newInventory = new Inventory();

        private IInventoryBL _inventoryBL;
        public AddInventoryMenu(IInventoryBL p_inventoryBL)
        {   
            _inventoryBL = p_inventoryBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter the inventory information");
            Console.WriteLine("[4] Quantity -" + _newInventory.Qty);
            Console.WriteLine("[3] Store ID -" + _newInventory.StoreID);
            Console.WriteLine("[2] Product ID -" + _newInventory.ProductID);
            Console.WriteLine("[1] SAVE Inventory");
            Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    try
                    {
                        Log.Information("Adding Inventory \n" + _newInventory);
                        _inventoryBL.AddInventory(_newInventory);
                        Log.Information("Successful at adding Inventory!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add Inventory");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter the product ID");
                    _newInventory.ProductID = Convert.ToInt32(Console.ReadLine());
                    return "AddInventory";
                case "3":
                    Console.WriteLine("Please enter the store ID");
                    _newInventory.StoreID = Convert.ToInt32(Console.ReadLine());
                    return "AddInventory";
                case "4":
                    Console.WriteLine("Please enter the Quantity");
                    _newInventory.Qty = Convert.ToInt32(Console.ReadLine());
                    return "AddInventory";
                default:
                    Console.WriteLine("Plese input a valid response");
                    Console.WriteLine("Plese press enter to continue");
                    Console.ReadLine();
                    return "AddInventory";
            }    
        }
    }
}