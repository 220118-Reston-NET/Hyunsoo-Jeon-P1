using System.Text.Json;
using Models;

namespace DL
{
    public class Repository : IRepository
    {
        private string _filepath = "../DL/Database/";
        private string _jsonString;
        private string _jsonString1;
        public Customer AddCustomer(Customer p_customer)
        {
            string path = _filepath + "Customer.json";

            List<Customer> listOfCustomer = GetAllCustomer();
            listOfCustomer.Add(p_customer);

            _jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString);

            return p_customer;
        }

        public List<Customer> GetAllCustomer()
        {
            _jsonString = File.ReadAllText(_filepath + "Customer.json");

            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
            
        }

        public List<Customer> GetCustomerByCustomerID(int p_customerID)
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product p_product)
        {
            string path = _filepath + "Product.json";
            
            List<Product> listOfProduct = GetAllProduct();
            listOfProduct.Add(p_product);

            _jsonString1 = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString1);

            return p_product;
        }

        public List<Product> GetAllProduct()
        {
            _jsonString = File.ReadAllText(_filepath + "Customer.json");

            return JsonSerializer.Deserialize<List<Product>>(_jsonString);
            
        }

        public StoreFront AddStoreFront(StoreFront p_storeFront)
        {
            string path = _filepath + "StoreFront.json";
            
            List<StoreFront> listOfStoreFront = GetAllStoreFront();
            listOfStoreFront.Add(p_storeFront);

            _jsonString1 = JsonSerializer.Serialize(listOfStoreFront, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString1);

            return p_storeFront;
        }

        public List<StoreFront> GetAllStoreFront()
        {
             _jsonString = File.ReadAllText(_filepath + "StoreFront.json");

            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }

        public List<Inventory> GetAllInventory()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllInventoryDetailInStoreByID(int p_storeId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(int p_storeId, int p_customerID, int p_totalPrice, List<LineItems> p_lineItem)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrdersByID(int p_customerID)
        {
            throw new NotImplementedException();
        }

        public void ReplenishInventory(int p_inventoryId, int p_qty)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetAllInventoryByID(int p_inventoryId)
        {
            throw new NotImplementedException();

        }

        public Inventory AddInventory(Inventory p_inventory)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllproductDetailByStoreID(int p_storeId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrdersByStoreID(int p_storeId)
        {
            throw new NotImplementedException();

        }
    }
}