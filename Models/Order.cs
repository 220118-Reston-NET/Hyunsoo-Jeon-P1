namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderCreated { get; set; }
        public List<LineItems> Cart { get; set; }
    
        
        public Order()
        {   
            OrderID = 0;
            TotalPrice = 0;
            StoreID = 0;
            CustomerID = 0;
            OrderCreated = DateTime.Now;
            Cart = new List<LineItems>();
        }

        // public override string ToString()
        // {
        //     return $"Order ID : {OrderID} \n Customer ID : {CustomerID} \n Store ID : {StoreID} \nTotal Price: {TotalPrice}";
        // }
    }
}