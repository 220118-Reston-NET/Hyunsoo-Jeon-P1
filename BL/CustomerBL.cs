using DL;
using Models;

namespace BL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Customer AddCustomer(Customer p_customer)
        {   
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            
            if(listOfCustomer.Count < 10)
            {
                return _repo.AddCustomer(p_customer);
            }
            else
            {
                throw new Exception("You cannot have more than 5 customers!");
            }

        }

        public List<Customer> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
        }
        public List<Customer> GetCustomerByCustomerID(int p_customerID)
        {
            return _repo.GetCustomerByCustomerID(p_customerID);
        }


        public List<Customer> SearchCustomerByName(string p_name)
        {   
            List<Customer> listOfCustomer = _repo.GetAllCustomer();

            return listOfCustomer.Where(customer => customer.Name.Contains(p_name)).ToList();
        }
    }
}