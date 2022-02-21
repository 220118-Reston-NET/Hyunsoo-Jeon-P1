namespace StoreUI
{
    public class AdminMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Good Day! ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] Searching menu");
            Console.WriteLine("[1] Adding menu");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput){
                case "0":
                    return "Exit";
                case "1":
                    return "AdminAddMenu";
                case "2":
                    return "AdminSearchMenu";
                default:
                    Console.WriteLine("Please input a vaild response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AdminMenu";
            }
        }
    }
}