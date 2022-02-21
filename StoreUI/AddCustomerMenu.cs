using Models;
using BL;

namespace StoreUI
{
    public class AddCustomerMenu : IMenu
    {
        private static Customer _newCustomer = new Customer();

        private ICustomerBL _customerBL;
        public AddCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        
        public void Display()
        {
            Console.WriteLine("Enter the customer information");
            Console.WriteLine("[5] Name -" + _newCustomer.Name);
            Console.WriteLine("[4] Contact No -" + _newCustomer.ContactNo);
            Console.WriteLine("[3] Address -" + _newCustomer.Address);
            Console.WriteLine("[2] Email -" + _newCustomer.Email);
            Console.WriteLine("[1] SAVE a new employee ");
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
                        Log.Information("Adding Customer \n" + _newCustomer);
                        _customerBL.AddCustomer(_newCustomer);
                        Log.Information("Successful at adding customer!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add Customer due to reaching total capacity (10)");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter email address");
                    _newCustomer.Email = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Please enter address");
                    _newCustomer.Address = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Please enter contact number");
                    _newCustomer.ContactNo = Console.ReadLine();
                    return "AddCustomer";
                case "5":
                    Console.WriteLine("Please enter name");
                    _newCustomer.Name = Console.ReadLine();
                    return "AddCustomer";
                default:
                    Console.WriteLine("Plese input a valid response");
                    Console.WriteLine("Plese press enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
        }
    }
}