using Models;

namespace BL
{   
    public interface IStoreFrontBL
    {
        StoreFront AddStoreFront(StoreFront p_storeFront);

        List<StoreFront> SearchStoreFront(string p_name);
        List<StoreFront> GetAllStoreFront();
    }
}