using BL;
using Models;

namespace StoreUI
{
    public class PlaceOrderCustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        public PlaceOrderCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
            _listOfCustomer = _customerBL.GetAllCustomer();

        }

        private List<Customer> _listOfCustomer;

        public static int _customerID;

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("[1] Press Customer ID");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "CustomerMenu";
                case "1":
                    Log.Information("User enter customer ID \n" + _customerID);

                    Console.WriteLine("Enter customer ID");
                    _customerID = Convert.ToInt32(Console.ReadLine());
            
                        while (_listOfCustomer.All(c => c.CustomerID != _customerID))
                        {
                            Console.WriteLine("You Id is not vaildate! Try again!");
                            _customerID = Convert.ToInt32(Console.ReadLine());

                        }
                        
                    return "PlaceOrderStore";
                default:
                   
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "CustomerMenu";
            }
        }
    }
}