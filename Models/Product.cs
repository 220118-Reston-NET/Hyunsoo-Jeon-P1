namespace Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }


        public Product(){
            ProductName = "";
            Price = 0;
        }
    }
}    
