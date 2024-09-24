using System.ComponentModel;
using System.Text;
using System.Text.Json.Nodes;
using ASP_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_01.Controllers {
    public class FirstController : Controller{

        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productService){
            _logger = logger;
            _env = env;
            _productService = productService;
        }
        public string Index() {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            // _logger.LogInformation("Index Logger");
            // _logger.LogWarning("LogWarning");
            // _logger.LogCritical("LogCritical");
            // _logger.LogDebug("LogDebug");
            // _logger.LogError("LogError");
            // _logger.LogTrace("LogTrace");
            return "Day la index firstcontroller";
        }
        public void Nothing() {
            _logger.LogInformation("Log Nothing");
            Response.Headers.Add("hi","Xin chap");
        }
        public object Everything() => DateTime.Now;

        public IActionResult Show(){
            var content = @"Đây là provip
            
            
            
            
            MUI;jaodfdaf";
            return Content(content, "text/plain", Encoding.UTF8);
        }
        public IActionResult FileAnh(){
            //_env.WebRootPath lấy file trong wwwroot
            string filePath = Path.Combine(_env.ContentRootPath,"Files","new1.jpg");
            if(System.IO.File.Exists(filePath)) {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes,"image/png");
            }
            else {
                return NotFound();
            }
        }
        // public IActionResult SamsungPrice(){
        //     return Json(
        //         new {
        //             productName: "aaa",
        //             price : 111
        //         }
        //     );
        // }
        public IActionResult Privacy(){
            var url = Url.Action("Privacy","Home");
            return LocalRedirect(url);
        }
        public IActionResult Google(){
            var url = "https://google.com";
            return Redirect(url);
        }
    // ViewResult                  | View()
        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username)){
                username = "Khách";
            }
            //View(template) - template đường dẫn tuyệt đối .cshtml
            //View(template, model)
            // return View("/MyView/xinchao.cshtml", username);

            //xinchao2.csthml -> View/First/xinchao2.cshtml
            // return View("xinchao2", username);

            //Tìm trùng tên Action -> View/First/HelloView.cshtml
            //View/Controller/Action.cshtml
            // return View((object) username);

            return View("xinchao", username);
        }
            [TempData]
            public string StatusMessage {get; set;}
        public IActionResult ViewProduct(int? id){


            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product == null){
                // TempData["StatusMessage"] = "Sản phẩm không có sẵn trong csdl";
               StatusMessage = "Sản phẩm bạn yêu cầu không có";
                return Redirect(Url.Action("Index", "Home"));
                
            }
            //View/First/ViewProduct.cshtml
            //Model
            // return View(product);

            //ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            //ViewBag
            ViewBag.product = product;
            return View("ViewProduct3");

        }
    }
}