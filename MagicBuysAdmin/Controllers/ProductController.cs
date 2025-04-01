using MagicBuysAdmin.Models;
using MagicBuysAdmin.ServiceContracts;
using MagicBuysAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagicBuysAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService pservice,IWebHostEnvironment env)
        {
            this._productService = pservice;
            this._env = env;
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

        [HttpGet]
        [Route("AddProduct")]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductAddModel _productAddModel)
        {
            if (_productAddModel.MainImage != null)
            {
                saveimage(_productAddModel.MainImage);
            }
            this._productService.AddProduct(_productAddModel);

            return RedirectToAction("ProductList");
        }

        string saveimage(IFormFile MainImage)
        {
            string fileName = Path.GetFileName(MainImage.FileName).Trim().Replace(" ","_");
            string filePath = Path.Combine(_env.WebRootPath, "Images", "Products", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                MainImage.CopyTo(stream);
            }

            return filePath;
        }


    }
}
