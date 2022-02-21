using BL;
using Models;

namespace StoreUI
{
    public class ViewOrderHistoryByStoreMenu : IMenu
    {
        private IOrderBL _orderBL;
        private List<Order> _listOfOrder;
        public ViewOrderHistoryByStoreMenu(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
            _listOfOrder = _orderBL.GetAllOrdersByStoreID(SearchOrderMenu._storeFrontId);

        }

        public void GetAllOrderDisplay()
        {
            foreach(var item in _listOfOrder)
            {
                Console.WriteLine(item);
                Console.WriteLine("********************");

            }
        }
        public void Display()
        {
            GetAllOrderDisplay();
            Console.WriteLine("********************");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "SearchOrder";
                default:
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewOrderHistoryByStore";
            }
        }
    }
}