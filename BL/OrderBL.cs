using DL;
using Models;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        private IRepository _repo;
        public OrderBL(IRepository p_repo)
        {
            _repo = p_repo;
        }


        public List<Order> GetAllOrder()
        {
            return _repo.GetAllOrder();
        }
        public List<LineItems> GetLineItemByOrderId(int p_orderId)
        {
            return _repo.GetLineItemByOrderId(p_orderId);
        }
        public void PlaceOrder(int p_storeId, int p_customerID, decimal p_totalPrice, List<LineItems> p_lineItem)
        {
            _repo.PlaceOrder(p_storeId, p_customerID, p_totalPrice, p_lineItem);
        }

        public List<Order> GetAllOrdersByCustomerID(int p_customerID)
        {   
            return GetAllOrder().FindAll(p => p.CustomerID == p_customerID);
        }

        public List<Order> GetAllOrdersByStoreID(int p_storeId)
        {
            return _repo.GetAllOrdersByStoreID(p_storeId);
        }

        public List<Order> GetAllOrdersByID(int p_orderID)
        {
            throw new NotImplementedException();
        }

        public Order AddOrder(Order p_order)
        {
            List<Order> listOfOrder = _repo.GetAllOrder();
            return _repo.AddOrder(p_order);
        }

        public Customer AddCustomer(Customer p_customer)
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();

            if (listOfCustomer.Count < 10)
            {
                return _repo.AddCustomer(p_customer);
            }
            else
            {
                throw new Exception("You cannot have more than 5 customers!");
            }

        }
    }
}