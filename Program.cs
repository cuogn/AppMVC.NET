using System.Configuration;
using System.Data.Entity;
using App.Models;
using ASP_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
builder.Services.AddSingleton(typeof(PlanetService), typeof(PlanetService));

builder.Services.AddDbContext<AppDbContext>(options => {
    string connectString = builder.Configuration.GetConnectionString("AppMvcConnectionString");
    options.UseSqlServer(connectString);
});

var env = builder.Environment;
builder.Services.Configure<RazorViewEngineOptions>(options => {
    //View/Controller/Action.cshtml
    //MyView/Controller/Action.cshtml

    //{0} -> Action
    //{1} -> Controller
    //{2} -> TenArea
    options.ViewLocationFormats.Add("/MyView/{1}/{0}"+RazorViewEngine.ViewExtension);
});

// builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!env.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseStatusCodePages(); //tạo response từ lỗi 400 trở đi

app.UseRouting();

app.UseAuthorization(); //kiểm tra quyền truy cập
app.MapRazorPages();

app.MapAreaControllerRoute(
    name: "product",
    areaName: "ProductManage",
    pattern: "{controller}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



//Url :start-here -> Route đến /FirstController/ViewProductAction/id=3
app.MapControllerRoute(
    name: "first",
    pattern: "{url}/{id?}",
    defaults: new {
        controller = "First",
        action = "ViewProduct"
    },
    constraints: new {
        url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
        id = new RangeRouteConstraint(2,4)
    }
);
;
app.MapRazorPages();
app.Run();
