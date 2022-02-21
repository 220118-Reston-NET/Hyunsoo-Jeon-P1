using Models;

namespace BL
{   
    public interface IProductBL
    {
        Product AddProduct(Product p_product);

        List<Product> SearchProduct(string p_name);

        List<Product> GetAllProdct();
    }
}