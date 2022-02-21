using BL;
using Models;

namespace StoreUI
{
    public class ViewOrderHistoryMenu : IMenu
    {
        private IOrderBL _orderBL;
        private List<Order> _listOfOrder;
        public static int _orderID;
        public ViewOrderHistoryMenu(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
            _listOfOrder = _orderBL.GetAllOrdersByID(PlaceOrderCustomerMenu._customerID);
        }

        public void All_Order_Display()
        {

            foreach (var item in _listOfOrder)
            {
                Console.WriteLine("********************");
                Console.WriteLine(item);
            }
        }
        public void Display()
        {
            All_Order_Display();
            Console.WriteLine("********************");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "PlaceOrderStore";
                default:
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}