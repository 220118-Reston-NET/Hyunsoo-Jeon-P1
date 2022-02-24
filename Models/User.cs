namespace Models
{
    public class User
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public User()
        {
            UserName = "Hyunsoo";
            Password = "1234";           
        }

        // public override string ToString()
        // {
        //     return $"Customer ID: {CustomerID} \nCustomer Name: {Name}\n Customer Address: {Address}\n Customer Email: {Email}\n Customer Contact number: {ContactNo}";
        // }
    }

}