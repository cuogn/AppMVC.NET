using ASP_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_01.Controllers
{
    [Area("ProductManage")]
    
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly ProductService _productService;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;

        }
        [Route("/cac-san-pham/{id?}")]
        public ActionResult Index()
        {
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }

    }
}
