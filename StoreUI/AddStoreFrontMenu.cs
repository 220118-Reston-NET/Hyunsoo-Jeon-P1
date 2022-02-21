using Models;
using BL;

namespace StoreUI
{
    public class AddStoreFrontMenu : IMenu 
    {
        private static StoreFront _newStoreFront = new StoreFront();

        private IStoreFrontBL _storeFrontBL;
        public AddStoreFrontMenu(IStoreFrontBL p__storeFrontBL)
        {
            _storeFrontBL = p__storeFrontBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter the store information");
            Console.WriteLine("[3] Store name -" + _newStoreFront.StoreName);
            Console.WriteLine("[2] Store Address -" + _newStoreFront.StoreAddress);
            Console.WriteLine("[1] SAVE product ");
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
                        Log.Information("Adding Store \n" + _newStoreFront);
                        _storeFrontBL.AddStoreFront(_newStoreFront);
                        Log.Information("Successful at adding Product!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add Product due to reaching total capacity (5)");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter the store address");
                    _newStoreFront.StoreAddress = Console.ReadLine();
                    return "AddStoreFront";
                case "3":
                    Console.WriteLine("Please enter the store name");
                    _newStoreFront.StoreName = Console.ReadLine();
                    return "AddStoreFront";
                default:
                    Console.WriteLine("Plese input a valid response");
                    Console.WriteLine("Plese press enter to continue");
                    Console.ReadLine();
                    return "AddStoreFront";
            }
        }
    }
}