namespace StoreUI
{
    public class CustomerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Good Day! ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[3] Sign up");
            Console.WriteLine("[2] Log in");
            Console.WriteLine("[1] Search Product");
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
                    return "SearchProduct";
                case "2":
                    return "PlaceOrderCustomer";
                case "3":
                    return "AddCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "CustomerMenu";          
                
            }
        }
    }
}