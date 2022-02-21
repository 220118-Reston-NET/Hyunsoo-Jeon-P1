global using Serilog;
using StoreUI;
using BL;
using DL;
using Microsoft.Extensions.Configuration;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt").CreateLogger();

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

string _connectionString = configuration.GetConnectionString("Reference2DB");


bool repeat = true;
IMenu menu = new MainMenu();

while(repeat){
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch(ans){
        case "ViewOrderHistoryByStore":
            menu = new ViewOrderHistoryByStoreMenu(new OrderBL(new SQLRepository(_connectionString)));
            break;
        case "RestockInventory":
            menu = new RestockInventoryMenu(new InventoryBL(new SQLRepository(_connectionString)));
            break;
        case "RestockInventoryDetail":
            menu = new RestockInventoryDetailMenu(new InventoryBL(new SQLRepository(_connectionString)));
            break;
        case "ViewOrderHistory":
            menu = new ViewOrderHistoryMenu(new OrderBL(new SQLRepository(_connectionString)));
            break;            
        case "PlaceOrderDetail": 
            menu = new PlaceOrderDetailMenu(new InventoryBL(new SQLRepository(_connectionString)),
                    new OrderBL(new SQLRepository(_connectionString)));                 
            break;
        case "PlaceOrderCustomer":
            menu = new PlaceOrderCustomerMenu(new CustomerBL(new SQLRepository(_connectionString)));
            break;
        case "PlaceOrderStore":
            menu = new PlaceOrderStoreMenu(new StoreFrontBL(new SQLRepository(_connectionString)),
                new CustomerBL(new SQLRepository(_connectionString)));
            break;
        case "SearchOrder":
            Log.Information("Displaying Search Order Menu to user");
            menu = new SearchOrderMenu(new OrderBL(new SQLRepository(_connectionString)), 
                new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "SearchInventoryStore":
            Log.Information("Displaying Search invetory store Menu to user");
            menu = new SearchStoreInventoryMenu(new InventoryBL(new SQLRepository(_connectionString)));
            break;
        case "SearchProduct":
            Log.Information("Displaying Search product Menu to user");
            menu = new SearchProductMenu(new ProductBL(new SQLRepository(_connectionString)));
            break;
        case "SearchCustomer":
            Log.Information("Displaying Search Customer Menu to user");
            menu = new SearchCustomerMenu(new CustomerBL(new SQLRepository(_connectionString)));
            break;
        case "SearchStoreFront":
            Log.Information("Displaying Search store Menu to user");
            menu = new SearchStoreFrontMenu(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;            
        case "AddProduct":
            Log.Information("Displaying Adding product Menu to user");
            menu = new AddProductMenu(new ProductBL(new SQLRepository(_connectionString)));
            break;
        case "AddCustomer":
            Log.Information("Displaying Adding customer Menu to user");
            menu = new AddCustomerMenu(new CustomerBL(new SQLRepository(_connectionString)));
            break;
        case "AddStoreFront":
            Log.Information("Displaying Adding Store Menu to user");
            menu = new AddStoreFrontMenu(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "AddInventory":
            Log.Information("Displaying Adding Inventory Menu to user");
            menu = new AddInventoryMenu(new InventoryBL(new SQLRepository(_connectionString)));
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "CustomerMenu":
            menu = new CustomerMenu();
            break;
        case "AdminMenu":
            menu = new AdminMenu();
            break;
        case "AdminAddMenu":
            menu = new AdminAddMenu();
            break;
        case "AdminSearchMenu":
            menu = new AdminSearchMenu();
            break;
        case "Exit":
            Log.Information("Exiting application");
            Log.CloseAndFlush(); 
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}