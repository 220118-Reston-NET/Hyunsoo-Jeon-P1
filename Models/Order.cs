namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderCreated { get; set; }
        
        private List<LineItems> _lineItems;
        public List<LineItems> LineItems
        {
            get { return _lineItems; }
            set { _lineItems = value; }
        }
        
        
        public Order()
        {   
            OrderID = 0;
            TotalPrice = 0;
            StoreID = 0;
            CustomerID = 0;
            OrderCreated = DateTime.Now;
            LineItems = new List<LineItems>()
            {
                new LineItems()
            };
        }

        // public override string ToString()
        // {
        //     return $"Order ID : {OrderID} \n Customer ID : {CustomerID} \n Store ID : {StoreID} \nTotal Price: {TotalPrice}";
        // }
    }
}