using System.Data.SqlClient;
using Models;

namespace DL
{
    public class SQLRepository : IRepository
    {

        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Customer AddCustomer(Customer p_customer)
        {
            string sqlQuery = @"insert into Customer
                            values(@customerName, @customerAddress, @customerEmail, @customerContactNo)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerName", p_customer.Name);
                command.Parameters.AddWithValue("@customerAddress", p_customer.Address);
                command.Parameters.AddWithValue("@customerEmail", p_customer.Email);
                command.Parameters.AddWithValue("@customerContactNo", p_customer.ContactNo);

                command.ExecuteNonQuery();
            }
            return p_customer;
        }

        public Product AddProduct(Product p_product)
        {
            string sqlQuery = @"insert into Product
                            values(@productName, @productPrice)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productName", p_product.ProductName);
                command.Parameters.AddWithValue("@productPrice", p_product.Price);

                command.ExecuteNonQuery();
            }
            return p_product;
        }

        public StoreFront AddStoreFront(StoreFront p_storeFront)
        {
            string sqlQuery = @"insert into StoreFront
                            values(@storeName, @storeAddress)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeName", p_storeFront.StoreName);
                command.Parameters.AddWithValue("@storeAddress", p_storeFront.StoreAddress);

                command.ExecuteNonQuery();
            }
            return p_storeFront;
        }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> listOfCustomer = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer()
                    {
                        CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        ContactNo = reader.GetString(4)
                    });
                }
            }
            return listOfCustomer;
        }

        public Inventory AddInventory(Inventory p_inventory)
        {
            string sqlQuery = @"insert into Inventory
                            values(@qty, @storeId, @productId)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@qty", p_inventory.Qty);
                command.Parameters.AddWithValue("@storeId", p_inventory.StoreID);
                command.Parameters.AddWithValue("@productId", p_inventory.ProductID);


                command.ExecuteNonQuery();
            }
            return p_inventory;
        }
        public List<Product> GetAllProduct()
        {
            List<Product> listOfProduct = new List<Product>();

            string sqlQuery = @"select * from Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProduct.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2),
                    });
                }
            }
            return listOfProduct;
        }

        public List<Product> GetAllProductByProductID(int p_productId)
        {
            List<Product> listOfProductDetail = new List<Product>();
            string sqlQuery = @"select * from product p
                                where p.productId = @productId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productId", p_productId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProductDetail.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2)
                    });
                }
            }
            return listOfProductDetail;
        }
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> _listOfinventory = new List<Inventory>();

            string sqlQuery = $"select * from Inventory";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _listOfinventory.Add(new Inventory()
                    {
                        InventoryID = reader.GetInt32(0),
                        Qty = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        ProductID = reader.GetInt32(3),
                    });
                }

            }

            return _listOfinventory;
        }

        public List<Inventory>GetAllInventoryByID(int p_inventoryId)
        {
            List<Inventory> _listOfInventory = new List<Inventory>();

            string sqlQuery = @"select * from Inventory
                                where inventoryId = @inventoryId";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@inventoryId", p_inventoryId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _listOfInventory.Add(new Inventory()
                    {
                        InventoryID = reader.GetInt32(0),
                        Qty = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        ProductID = reader.GetInt32(3),
                    });
                }
                
            }

            return _listOfInventory;
        }


        public List<StoreFront> GetAllStoreFront()
        {
            List<StoreFront> listOfStoreFront = new List<StoreFront>();

            string sqlQuery = @"select * from StoreFront";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStoreFront.Add(new StoreFront()
                    {
                        StoreID = reader.GetInt32(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2),
                    });
                }
            }
            return listOfStoreFront;
        }


        public List<Customer> GetCustomerByCustomerID(int p_customerID)
        {
            List<Customer> listOfCustomer = new List<Customer>();
            string sqlQuery = @"select * from Customer c
                                where c.customerID = @customerID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerID", p_customerID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer()
                    {
                        CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        ContactNo = reader.GetString(4)
                    });
                }
            }
            return listOfCustomer;
        }

        public List<Product> GetAllInventoryDetailInStoreByID(int p_storeId)
        {

            List<Product> _listOfInventory = new List<Product>();
            string sqlQuery = @"select p.productId, p.productName, p.productPrice, i.qty from Product p
                            inner join Inventory i on p.productId = i.productId 
                            inner join StoreFront sf on sf.storeId = i.storeId
                            where i.productId = p.productId AND i.storeId = @storeId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeId", p_storeId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _listOfInventory.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2),

                    });
                }
            }
            return _listOfInventory;
        }

        public List<Order> GetAllOrder()
        {
            List<Order> _listOfOrder = new List<Order>();

            string sqlQuery = @"select * from Orders o";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _listOfOrder.Add(new Order()
                    {
                        OrderID = reader.GetInt32(0),
                        TotalPrice = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        CustomerID = reader.GetInt32(3),
                    });
                }
            }
            return _listOfOrder;
        }

        public List<Order> GetAllOrdersByID(int p_customerId)
        {
            List<Order> _listOfOrder = new List<Order>();
            string sqlQuery = @"select * from Orders o 
                                where o.customerId = @customerId
                                order by orderId desc";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerId", p_customerId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _listOfOrder.Add(new Order()
                    {
                        OrderID = reader.GetInt32(0),
                        TotalPrice = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        CustomerID = reader.GetInt32(3)
                    });
                }
            }
            return _listOfOrder;
        }


        public List<Order> GetAllOrdersByStoreID(int p_storeId)
        {
            List<Order> _listOfOrderByStore = new List<Order>();
            string sqlQuery = @"select * from Orders o
                                where o.storeId = @storeId
                                order by orderId desc";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeId", p_storeId);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    _listOfOrderByStore.Add(new Order(){
                        OrderID = reader.GetInt32(0),
                        TotalPrice = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        CustomerID = reader.GetInt32(3)
                    });
                }
            }
            return _listOfOrderByStore;
        }


        public void PlaceOrder(int p_storeId, int p_customerID, int p_totalPrice, List<LineItems> p_lineItem)
        {
            string sqlQueryOrder = @"insert into Orders
                            values(@orderTotalPrice, @storeId, @customerID);
                            select scope_identity();";

            string sqlQueryLineItem = @"insert into LineItem
                                    values(@qty, @orderId, @productId)";

            string sqlQuerySubstractInvetory = @"update Inventory
                                                set qty = qty - @qty
                                                where storeId  = @storeId AND productId = @productId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQueryOrder, con);
                command.Parameters.AddWithValue("@orderTotalPrice", p_totalPrice);
                command.Parameters.AddWithValue("@storeId", p_storeId);
                command.Parameters.AddWithValue("@customerID", p_customerID);

                //command.ExecuteNonQuery();

                int orderId = Convert.ToInt32(command.ExecuteScalar());

                foreach (var item in p_lineItem)
                {
                    SqlCommand command2 = new SqlCommand(sqlQueryLineItem, con);
                    command2.Parameters.AddWithValue("@qty", item.Qty);
                    command2.Parameters.AddWithValue("@orderId", orderId);
                    command2.Parameters.AddWithValue("@productId", item.ProductID);
                 
                    command2.ExecuteNonQuery();

                    SqlCommand command3 = new SqlCommand(sqlQuerySubstractInvetory, con);
                    command3.Parameters.AddWithValue("@qty", item.Qty);
                    command3.Parameters.AddWithValue("@storeId", p_storeId);
                    command3.Parameters.AddWithValue("@productId", item.ProductID);

                    command3.ExecuteNonQuery();
                }

            }
        }

        public List<Product> GetAllproductDetailByStoreID(int p_storeId)
        {
            string sqlQuery = @"select p.productId, p.productName, p.productPrice 
                                from product p, Inventory i 
                               where p.productId = i.productId AND i.storeId = @p_storeId";

            List<Product> _newListProduct = new List<Product>();

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.AddWithValue("@p_storeId", p_storeId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _newListProduct.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2)
                    });
                }

            }
            return _newListProduct;
        }

        public void ReplenishInventory(int p_inventoryId, int p_qty)
        {
            string sqlQuery = @"update Inventory
                                set qty = qty + @qty
                                where inventoryId = @p_inventoryId ";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@qty", p_qty);
                command.Parameters.AddWithValue("p_inventoryId", p_inventoryId);

                command.ExecuteNonQuery();
            }
        }



    }
}

