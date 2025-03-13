using MagicBuysAdmin.Models;
using MagicBuysAdmin.ServiceContracts;
using MagicBuysAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagicBuysAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
       
        public ProductController(IProductService pservice)
        {
            this._productService = pservice;
        }

        [Route("/")]
        public IActionResult ProductList()
        {
           ViewBag.object1 = "Access to viewbag";
           TempData["object1"] = "First access to tempdata of view";

            List<ProductModel> products = this._productService.ListProducts();
            return View(products);
        }

        [Route("Product/{ID}")]
        public string GetProductByID(int id)
        {
            return id.ToString();
        }

        [Route("ProductDelete/{ID}")]
        public string DeleteProduct(int id)
        {
            return "Delete Product "+ id.ToString();
        }

        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }


       
    }
}
