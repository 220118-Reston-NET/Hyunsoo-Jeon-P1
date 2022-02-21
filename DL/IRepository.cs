using Models;

namespace DL
{
    public interface IRepository
    {
        Customer AddCustomer(Customer p_customer);
        List<Customer> GetAllCustomer();

        List<Customer> GetCustomerByCustomerID(int p_customerID);

        Product AddProduct(Product p_product);
        List<Product> GetAllProduct();

        StoreFront AddStoreFront(StoreFront p_storeFront);
        List<StoreFront> GetAllStoreFront();
        List<Inventory> GetAllInventory();
        void PlaceOrder(int p_storeId, int p_customerID, int p_totalPrice, List<LineItems> p_lineItem);
        List<Product> GetAllInventoryDetailInStoreByID(int p_storeId);

        Inventory AddInventory(Inventory p_inventory);

        List<Order> GetAllOrder();
        List<Order> GetAllOrdersByID(int p_customerID);

        List<Product> GetAllproductDetailByStoreID(int p_storeId);
        void ReplenishInventory(int p_inventoryId, int p_qty);
        public List<Inventory> GetAllInventoryByID(int p_inventoryId);
        public List<Order> GetAllOrdersByStoreID(int p_storeId);

    }
}