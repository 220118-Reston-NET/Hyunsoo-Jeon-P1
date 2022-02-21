namespace StoreUI
{
    public class AdminSearchMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Good Day! ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[5] Search / view orders");
            Console.WriteLine("[4] Search Store Inventory by store Id");
            Console.WriteLine("[3] Search Store");
            Console.WriteLine("[2] Search Product");
            Console.WriteLine("[1] Search Customer");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "SearchCustomer";
                case "2":
                    return "SearchProduct";
                case "3":
                    return "SearchStoreFront";
                case "4":
                    return "SearchInventoryStore";
                case "5":
                    return "SearchOrder";
                default:
                    Console.WriteLine("Please input a vaild response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AdminMenu";
            }
        }
    }
}