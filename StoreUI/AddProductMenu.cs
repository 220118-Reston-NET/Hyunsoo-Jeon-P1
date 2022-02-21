using Models;
using BL;

namespace StoreUI
{
    public class AddProductMenu : IMenu 
    {
        private static Product _newProduct = new Product();

        private IProductBL _productBL;
        public AddProductMenu(IProductBL p_productBL)
        {
            _productBL = p_productBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter the product information");
            Console.WriteLine("[3] Product Name -" + _newProduct.ProductName);
            Console.WriteLine("[2] Price -" + _newProduct.Price);
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
                        Log.Information("Adding Product \n" + _newProduct);
                        _productBL.AddProduct(_newProduct);
                        Log.Information("Successful at adding Product!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add Product due to reaching total capacity (10)");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter the price of the product");
                    _newProduct.Price = Convert.ToInt32(Console.ReadLine());
                    return "AddProduct";
                case "3":
                    Console.WriteLine("Please enter the name");
                    _newProduct.ProductName = Console.ReadLine();
                    return "AddProduct";
                default:
                    Console.WriteLine("Plese input a valid response");
                    Console.WriteLine("Plese press enter to continue");
                    Console.ReadLine();
                    return "AddProduct";
            }
        }
    }
}