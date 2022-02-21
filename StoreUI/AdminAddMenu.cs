namespace StoreUI
{
    public class AdminAddMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Good Day! ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[4] Restock Inventory");
            Console.WriteLine("[3] Add Inventory");
            Console.WriteLine("[2] Add Store Front");
            Console.WriteLine("[1] Add product ");
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
                    return "AddProduct";
                case "2":
                    return "AddStoreFront";
                case "3":
                    return "AddInventory";
                case "4":
                    return "RestockInventory";
                default:
                    Console.WriteLine("Please input a vaild response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AdminMenu";
            }
        }
    }
}