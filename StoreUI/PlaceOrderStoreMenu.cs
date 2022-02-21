using BL;
using Models;

namespace StoreUI
{
    public class PlaceOrderStoreMenu : IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        private ICustomerBL _customerBL;
        public PlaceOrderStoreMenu(IStoreFrontBL p_storeFrontBL, ICustomerBL p_customerBL)
        {
            _storeFrontBL = p_storeFrontBL;
            _customerBL = p_customerBL;
            _listOfStoreFront = _storeFrontBL.GetAllStoreFront();
            _listOfCustomer = _customerBL.GetCustomerByCustomerID(PlaceOrderCustomerMenu._customerID);

        }

        public static StoreFront _storeNameSelect = new StoreFront();
        private List<StoreFront> _listOfStoreFront;
        private List<Customer> _listOfCustomer;

        public static int _storeID;

        public void CustomerWelcome_Display()
        {
            foreach (var item in _listOfCustomer)
            {
                Console.WriteLine("Welcome " + item.Name);
            }
        }
        public void StoreFront_ProductDisplay(){
            foreach(var item in _listOfStoreFront)
            {
                Console.WriteLine("********************");
                Console.WriteLine(item);
            }
        }
        public void Display()
        {
            Console.Clear();
            CustomerWelcome_Display();
            StoreFront_ProductDisplay();

            Console.WriteLine("********************");
            Console.WriteLine("[2] View Orders");
            Console.WriteLine("[1] Press Store ID to contine order");
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
                    Log.Information("User enter the store id and procede to order details\n" + _storeID);

                    Console.WriteLine("Enter Store ID");
                    _storeID = Convert.ToInt32(Console.ReadLine());
      
                        while(_listOfStoreFront.All(p => p.StoreID != _storeID))
                        {
                            Console.WriteLine("You Id is not vaildate! Try again!");
                            _storeID = Convert.ToInt32(Console.ReadLine());
                            
                        }
                   
                return "PlaceOrderDetail";
                case "2":
                   return "ViewOrderHistory";
            default:
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "PlaceOrderStore";          
            }
        }
    }
}