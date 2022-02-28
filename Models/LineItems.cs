namespace Models
{
    public class LineItems
    {
        public int ProductID { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }           
        public int Qty { get; set; }

        public LineItems()
        {
            ProductName = "";
            Price = 0;
            Qty = 0;
        }

        // public override string ToString()
        // {
        //     return $"Product name : {ProductName}\n Price : {Price} \n Quantity: {Qty}";
        // }
    }
}