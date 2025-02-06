using Microsoft.AspNetCore.Mvc;
using MVCClient.Services;

namespace MVCClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _productService.GetProductAsync(id));
        }
    }
}
