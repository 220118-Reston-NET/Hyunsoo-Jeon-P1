namespace Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }

        public Inventory()
        {
            InventoryID = 0;
            StoreID = 0;
            ProductID = 0;
            Qty = 0;
        }

        // public override string ToString()
        // {
        //     return $"Inventory ID : {InventoryID}\n Store ID: {StoreID} Product ID: {ProductID} \n Quantity : {Qty}";
        // }
    }
}