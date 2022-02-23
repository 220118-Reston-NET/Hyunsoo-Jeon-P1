namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TotalPrice { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        
        
        private List<LineItems> _lineItems;
        public List<LineItems> LineItems
        {
            get { return _lineItems; }
            set { _lineItems = value; }
        }
        
        
        public Order()
        {   
            OrderID = 1;
            TotalPrice = 15;
            StoreID = 1;
            CustomerID = 1;
            LineItems = new List<LineItems>()
            {
                new LineItems()
            };
        }

        public override string ToString()
        {
            return $"Order ID : {OrderID} \n Customer ID : {CustomerID} \n Store ID : {StoreID} \nTotal Price: {TotalPrice}";
        }
    }
}