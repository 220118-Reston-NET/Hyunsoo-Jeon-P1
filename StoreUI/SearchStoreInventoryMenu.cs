using BL;
using Models;

namespace StoreUI
{  
    public class SearchStoreInventoryMenu: IMenu
    {
        private List<Inventory> _listOfProduct;
        private IProductBL _productBL;
        private IInventoryBL _inventoryBL;
        private InventoryBL inventoryBL;

        public SearchStoreInventoryMenu(IInventoryBL p_inventoryBL)
        {
            _inventoryBL = p_inventoryBL;
            _listOfProduct = _inventoryBL.GetAllInventory();

        }

        public SearchStoreInventoryMenu(IProductBL p_productBL)
        {
            _productBL = p_productBL;
        }
        private List<Inventory> listOfInventory; 
        public void Display()
       {
           listOfInventory = _inventoryBL.GetAllInventory();
            foreach(var item in listOfInventory)
            {
                Console.WriteLine("********************");
                Console.WriteLine(item);
            }
            Console.WriteLine("Please enter store id database");
            Console.WriteLine("[1] Store ID");
            Console.WriteLine("[0] Go back");
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
                        Console.WriteLine("Please enter a store ID");
                        int storeId = Convert.ToInt32(Console.ReadLine());
                        Log.Information("User enter the store id to check inventory \n" + storeId);

                        List<Inventory> listOfProduct = _inventoryBL.GetAllInventoryDetailInStoreByID(storeId);
                        foreach(var item in listOfProduct)
                        {
                            Console.WriteLine("********************");
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();

                       return "MainMenu";
                    }
                     catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return "SearchInventoryStore";
                    }
                    return "SearchInventoryStore";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchInventoryStore";              
           }
       }

    }
}