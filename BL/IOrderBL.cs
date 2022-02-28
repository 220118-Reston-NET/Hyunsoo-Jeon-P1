using Models;

namespace BL
{   
    public interface IOrderBL
    {
        List<Order> GetAllOrder();
        
        void PlaceOrder(int p_storeId, int p_customerID, decimal p_totalPrice, List<LineItems> p_lineItem);

        List<Order> GetAllOrdersByID(int p_orderID);
        List<Order> GetAllOrdersByStoreID(int p_storeId);
        List<Order> GetAllOrdersByCustomerID(int p_customerID);
        Order AddOrder(Order p_order);
        List<LineItems> GetLineItemByOrderId(int p_orderId);
    }
}