using Models;

namespace BL
{   
    public interface ICustomerBL
    {
        Customer AddCustomer(Customer p_customer);
        List<Customer> GetAllCustomer();
        List<Customer> SearchCustomerByName(string p_name);

        List<Customer> GetCustomerByCustomerID(int p_customerID);
    }
}