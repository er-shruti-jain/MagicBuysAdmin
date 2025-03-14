using MagicBuysAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicBuysAdmin.ServiceContracts
{
    public interface IProductService
    {
        public List<ProductModel> ListProducts();

        public void DeleteProduct(int id);

        public void AddProduct(ProductAddModel product);
    }
}
