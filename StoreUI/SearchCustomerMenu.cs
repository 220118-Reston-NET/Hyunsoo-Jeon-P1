using BL;
using Models;

namespace StoreUI
{  
   public class SearchCustomerMenu: IMenu
   {
       private List<Customer> _listOfCustomer;
       private ICustomerBL _customerBL;
       public SearchCustomerMenu(ICustomerBL p_customerBL)
       {
           _customerBL = p_customerBL;
           _listOfCustomer = _customerBL.GetAllCustomer();
       }

       public void Display()
       {
            Console.WriteLine("Please select an option to filter the customer database");
            Console.WriteLine("[2] By Customer ID");
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

                    Console.WriteLine("Please enter a name");
                    string name = Console.ReadLine();
                    Log.Information("User enter the customer name \n" + name);

                    List<Customer> listOfCustomer = _customerBL.SearchCustomerByName(name);
                    foreach(var item in listOfCustomer)
                    {
                        Console.WriteLine("********************");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();

                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter a Customer ID");

                    try
                    {
                        int customerID = Convert.ToInt32(Console.ReadLine());
                        Log.Information("User enter the customer id to search customer\n" + customerID);

                        List<Customer> listOfCustomer2 = _customerBL.GetCustomerByCustomerID(customerID);
                        foreach(var item in listOfCustomer2)
                        {
                            Console.WriteLine("====================");
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();

                        return "AdminMenu";
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return "SearchCustomer";
                    }
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";              
           }
       }
   } 
}