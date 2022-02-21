namespace Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        private int _price;
        public int Price
        {
            get { return _price; }
            set { 
                    if(value >=0)
                    {
                        _price = value; 
                    }
                    else 
                    {
                        throw new Exception("Price should not be negative value");
                    }
                }    
        }


        public Product(){
            ProductName = "Coolant";
            Price = 15;
        }
        public override string ToString()
        {
            return $"Product ID: {ProductID} \nProduct Name: {ProductName}\n Price: {Price}";
        }
    }
}    
