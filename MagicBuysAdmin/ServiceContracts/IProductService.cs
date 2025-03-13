using MagicBuysAdmin.Models;

namespace MagicBuysAdmin.ServiceContracts
{
    public interface IProductService
    {
        public List<ProductModel> ListProducts();
    }
}
