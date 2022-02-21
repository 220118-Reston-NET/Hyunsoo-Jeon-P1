using BL;
using Models;

namespace StoreUI
{  
    public class SearchProductMenu: IMenu
    {
        private IProductBL _productBL;
        public SearchProductMenu(IProductBL p_productBL)
        {
            _productBL = p_productBL;
        }

        public void Display()
       {
            Console.WriteLine("Please select an option to filter the product database");
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

                    Console.WriteLine("Please enter a product name");
                    string productName = Console.ReadLine();
                    Log.Information("User enter the product name to search product detail\n" + productName);

                    List<Product> listOfProduct = _productBL.SearchProduct(productName);
                    foreach(var item in listOfProduct)
                    {
                        Console.WriteLine("********************");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();

                    return "CustomerMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchProduct";              
           }
       }

    }
}