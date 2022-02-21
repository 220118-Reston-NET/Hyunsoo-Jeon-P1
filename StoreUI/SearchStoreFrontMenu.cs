using BL;
using Models;

namespace StoreUI
{  
    public class SearchStoreFrontMenu: IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        public SearchStoreFrontMenu(IStoreFrontBL p__storeFrontBL)
        {
            _storeFrontBL = p__storeFrontBL;
        }

        public void Display()
       {
            Console.WriteLine("Please select an option to filter the Store database");
            Console.WriteLine("[1] By Name");
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

                    Console.WriteLine("Please enter a Store name");
                    string storeName = Console.ReadLine();
                    Log.Information("User enter the store name to search store detail\n" + storeName);

                    List<StoreFront> listOfStoreFront = _storeFrontBL.SearchStoreFront(storeName);
                    foreach(var item in listOfStoreFront)
                    {
                        Console.WriteLine("********************");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();

                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchStoreFront";              
           }
       }

    }
}