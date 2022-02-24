namespace Models
{
    public class StoreFront
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string  UserName { get; set; }
        public StoreFront(){
            StoreName="";
            StoreAddress="";
            UserName ="";
        }

        // public override string ToString()
        // {
        //     return $"Store ID: {StoreID} \n Store Name: {StoreName}\n Store Address: {StoreAddress}";
        // }

    }
}