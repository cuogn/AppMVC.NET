1. Controller: Nhận Request client gửi đến và gửi Response lại cho client
2. Model: Cấu trúc dữ liệu của ứng dụng
   pattern: “{controller=Home}/{action/Index}/{id?}”
    URL: /{controller}/{action}/{id?}
    VD: /Home/Index => Controller: HomeController, method Index (trong HomeController)

##Controller

- Là 1 lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Trong controller chứa tất cả thông tin Request gửi đến.
  Logger: lưu lại thông tin, dấu vết hoạt động của ứng dụng
  Trong asp Logger đã được inject sẵn
  builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); //Serilog
  IActionResult: View: sử dụng Razor engine đọc và thi hành file.cshtml (template).
  Tạo model, truyền dữ liệu giữa các thành phần của ứng dụng
  Services.AddSingleton: chỉ tạo ra 1 đối tượng dịch vụ
  Services.AddTransient: mỗi lần truy vấn để lấy ra dịch vụ thì 1 đối tượng mới được tạo ra.
  Services.AddScoped: mỗi phiên truy cập thì 1 đối tượng mới được tạo ra.

3 cách đổ dữ liệu qua view
1 – thông qua Model
2 – thông qua ViewData
Khi sử dụng ViewData, nó tự động nạp View con vào View cha, tức là nạp vào Layout
3 – thông qua ViewBag
Truyền dữ liệu từ trang này qua trang khác
TempData
[Attribute] like [Annotation]

##Area

- Là tên dùng để routing
- Là cấu trúc thư mục chứa M.V.C
- Thiết lập area cho controller bằng `[Area("AreaName")]`
- Tạo cấu trúc thư mục

```
dotnet aspnet-codegenerator area Product
```
