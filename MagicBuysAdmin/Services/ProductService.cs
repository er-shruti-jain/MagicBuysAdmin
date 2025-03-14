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

        public void AddProduct(ProductAddModel product)
        {
            ProductModel pm = new ProductModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity

            };
           pm= gstcalculate(pm);

            this._dbcontext.Products.Add(pm);
            this._dbcontext.SaveChanges();


        }

        public ProductModel gstcalculate(ProductModel pm)
        {
            pm.GST = 18;
            pm.Total = pm.Price + (pm.Price * pm.GST / 100);
            return pm;

        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> ListProducts()
        {
            List<ProductModel> pm = this._dbcontext.Products.ToList();
            return pm;
        }
        
    }
}
