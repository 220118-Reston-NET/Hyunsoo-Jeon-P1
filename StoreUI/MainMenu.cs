namespace StoreUI{
    public class MainMenu : IMenu{
        public void Display(){
            Console.WriteLine("Welcome to Car Parts Store!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] Customer Menu");
            Console.WriteLine("[1] Admin Menu ");
            Console.WriteLine("[0] Exit");
        }

        public string UserChoice(){
            string userInput = Console.ReadLine();

            switch(userInput){
                case "0":
                    return "Exit";
                case "1":
                    return "AdminMenu";
                case "2":
                    return "CustomerMenu";
                default:
                    Console.WriteLine("Please input a vaild response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}