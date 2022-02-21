namespace Models
{
    public class StoreFront
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public StoreFront(){
            StoreName="All parts 1";
            StoreAddress="7777 Main St, San Jose, CA 77777";
        }

        public override string ToString()
        {
            return $"Store ID: {StoreID} \n Store Name: {StoreName}\n Store Address: {StoreAddress}";
        }

    }
}