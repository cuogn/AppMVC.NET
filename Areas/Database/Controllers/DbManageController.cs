using System.Data.Entity;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DbManageController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: DbManageController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteDb(){
            return View();
        }

        [TempData]
        public string StatusMessage {get;set;}

        [HttpPost]
        public async Task<ActionResult> DeleteDbAsync(){
            var success = await _dbContext.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Xóa thành công" : "Xóa không được Database";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Migrate(){
            await _dbContext.Database.MigrateAsync();
            StatusMessage = "Cập nhật database thành công";
            return RedirectToAction(nameof(Index));
        }

    }
}
