using DL;
using Models;

namespace BL
{
    public class ProductBL : IProductBL
    {
        private IRepository _repo;
        public ProductBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Product AddProduct(Product p_product)
        {   
            List<Product> listOfProduct = _repo.GetAllProduct();
            
            if(listOfProduct.Count < 10)
            {
                return _repo.AddProduct(p_product);
            }
            else
            {
                throw new Exception("You cannot have more than 10 products!");
            }

        }

        public List<Product> GetAllProdct()
        {
            return _repo.GetAllProduct();
        }

        public List<Product> SearchProduct(string p_productName)
        {   
            List<Product> listOfProduct = _repo.GetAllProduct();

            return listOfProduct.Where(product => product.ProductName.Contains(p_productName)).ToList();
        }
    }
}