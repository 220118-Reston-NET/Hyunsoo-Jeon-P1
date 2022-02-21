using BL;
using Models;

namespace StoreUI
{  
    public class SearchOrderMenu: IMenu
    {
        private IOrderBL _orderBL;
        private IStoreFrontBL _storeFrontBL;
        private List<Order> _listOfOrder;
        private List<StoreFront> _listOfStoreFront;
        public static int _storeFrontId;
        public SearchOrderMenu(IOrderBL p_orderBL, IStoreFrontBL p_storeFrontBL)
        {
            _orderBL = p_orderBL;
            _storeFrontBL = p_storeFrontBL;
            _listOfOrder = _orderBL.GetAllOrder();
            _listOfStoreFront = _storeFrontBL.GetAllStoreFront();
        }

        public void Display()
       {
            Console.WriteLine("Please select an option to filter the order database");
            Console.WriteLine("[2] View orders by Store ID");
            Console.WriteLine("[1] view orders");
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
                    try
                    {
                        Log.Information("User view orders\n");

                        _listOfOrder = _orderBL.GetAllOrder();
                        foreach(var item in _listOfOrder)
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
                        return "SearchOrder";
                    } 
                case "2":
                    Log.Information("User enter Store ID \n" + _storeFrontId);

                    Console.WriteLine("Enter store ID");
                    _storeFrontId = Convert.ToInt32(Console.ReadLine());

                    while (_listOfStoreFront.All(p => p.StoreID != _storeFrontId))
                    {
                        Console.WriteLine("You Id is not vaildate! Try again!");
                        _storeFrontId = Convert.ToInt32(Console.ReadLine());

                    }

                    return "ViewOrderHistoryByStore";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchOrder";              
           }
       }

    }
}