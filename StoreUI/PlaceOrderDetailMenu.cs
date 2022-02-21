using BL;
using Models;

namespace StoreUI
{
    public class PlaceOrderDetailMenu : IMenu
    {
        private IOrderBL _orderBL;
        private IInventoryBL _inventoryBL;
        public PlaceOrderDetailMenu( IInventoryBL p_inventoryBL, IOrderBL p_orderBL)
        {
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
            _listOfInventory = _inventoryBL.GetAllInventoryDetailInStoreByID(PlaceOrderStoreMenu._storeID);
            _listOfProduct = _inventoryBL.GetAllproductDetailByStoreID(PlaceOrderStoreMenu._storeID);
      }

        private List<Inventory> _listOfInventory;
        private List<Product> _listOfProduct;
        private static List<LineItems> _cart = new List<LineItems>();


 
        public void StoreProduct_Display()
        {
            
            foreach (var item in _listOfProduct)
            {
                Console.WriteLine("********************");
                Console.WriteLine(item);

                Console.WriteLine("Quantity " + _listOfInventory.Find(p => p.ProductID == item.ProductID).Qty);
            }
        }
        public void Display()
        {
            StoreProduct_Display();

            Console.WriteLine("********************");
            Console.WriteLine("[3] View order detail");
            Console.WriteLine("[2] Place Order");
            Console.WriteLine("[1] Press Product Name to contine order");
            Console.WriteLine("[0] Go back");
            if(_cart.Count() != 0)
            {
                Console.WriteLine("In your cart");
                foreach(var item in _cart)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "PlaceOrderCustomer";
                case "1":
                    Log.Information("User enter the product name and quantity and to cart \n");

                    Console.WriteLine("Enter the product name");
                    string inputName =Console.ReadLine();

                    while (_listOfProduct.All(p => p.ProductName != inputName))
                    {
                        Console.WriteLine("You product name is not vaildate! Try again!");
                        inputName = Console.ReadLine();
                    
                    }
                    Console.WriteLine("Enter the product quantity");

                    string qty = Console.ReadLine();
                    while(qty != "" && !qty.All(Char.IsDigit))
                    {
                        
                        Console.WriteLine("You product quantity is not vaildate! Try again!");
                        qty = Console.ReadLine();
                    }

                    int currentProductId = _listOfProduct.Find(p => p.ProductName == inputName).ProductID;

                    if(Convert.ToInt32(qty) > _listOfInventory.Find(p => p.ProductID == currentProductId).Qty)
                    {
                        Console.WriteLine("Your Quantity is larger value than inventory!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return "PlaceOrderDetail";
                    }

                    _cart.Add(new LineItems(){
                        ProductID = _listOfProduct.Find(p => p.ProductName == inputName).ProductID,
                        ProductName = inputName,
                        Qty = Convert.ToInt32(qty),
                        Price = _listOfProduct.Find(p => p.ProductName == inputName).Price

                    });
                    return "PlaceOrderDetail";
                case "2":
                    Log.Information("User process Order \n" + _cart);

                    if(_cart.Count()== 0)
                    {
                        Console.WriteLine("Your cart is empty! go Shopping!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return "PlaceOrderDetail";
                    }
                    int _totalPrice = 0;
                    foreach(var item in _cart)
                    {
                        _totalPrice += item.Price * item.Qty;
                    }

                    _orderBL.PlaceOrder(PlaceOrderStoreMenu._storeID, PlaceOrderCustomerMenu._customerID, _totalPrice, _cart);
                    Console.WriteLine("Your Order is Success!");
                    Log.Information("Success order!");

                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewOrderHistory";
                case "3":
                    return "ViewOrderHistory";
                default:

                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "PlaceOrderDetail";
            }
        }
    }
}