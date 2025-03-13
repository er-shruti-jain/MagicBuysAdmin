using MagicBuysAdmin.Models;
using MagicBuysAdmin.Repository;
using MagicBuysAdmin.ServiceContracts;

namespace MagicBuysAdmin.Services
{
    public class ProductService : IProductService
    {
        private ProductDBContext _dbcontext;
        public ProductService(ProductDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<ProductModel> ListProducts()
        {
            List<ProductModel> pm = this._dbcontext.Products.ToList();
            return pm;
        }
        
    }
}
