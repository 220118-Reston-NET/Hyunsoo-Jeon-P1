using Models;

namespace BL
{   
    public interface IOrderBL
    {
        List<Order> GetAllOrder();

        void PlaceOrder(int p_storeId, int p_customerID, int p_totalPrice, List<LineItems> p_lineItem);

        List<Order> GetAllOrdersByID(int p_orderID);
        List<Order> GetAllOrdersByStoreID(int p_storeId);

    }
}