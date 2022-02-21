using DL;
using Models;

namespace BL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IRepository _repo;
        public StoreFrontBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public StoreFront AddStoreFront(StoreFront p_storeFront)
        {   
            List<StoreFront> listOfStoreFront = _repo.GetAllStoreFront();
            
            if(listOfStoreFront.Count < 10)
            {
                return _repo.AddStoreFront(p_storeFront);
            }
            else
            {
                throw new Exception("You cannot have more than 10 stores!");
            }

        }

        public List<StoreFront> GetAllStoreFront()
        {
            return _repo.GetAllStoreFront();
        }

        public List<StoreFront> SearchStoreFront(string p_storeFrontName)
        {   
            List<StoreFront> listOfStoreFront = _repo.GetAllStoreFront();

            return listOfStoreFront.Where(store => store.StoreName.Contains(p_storeFrontName)).ToList();
        }

    }
}