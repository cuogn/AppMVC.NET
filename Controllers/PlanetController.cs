using ASP_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_01.Controllers
{
    [Route("hemattroi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetsService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(ILogger<PlanetController> logger, PlanetService planetService){
            _logger = logger;
            _planetsService = planetService;
        }
        // GET: Planet
        [Route ("/danh-sach-cac-hanh-tinh")]
        public ActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {get;set;} //Action ~ Planet
        public ActionResult Mercury(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        public ActionResult Jupiter(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        public ActionResult Mars(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        public ActionResult Earth(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        public ActionResult Neptune(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        public ActionResult Saturn(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        public ActionResult Uranus(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
        //Sử dụng token
        [Route("sao/[action]", Order = 1, Name = "neptune3")]
        [Route("sao/[controller]/[action]", Order = 2, Name = "neptune2")]
        [Route("[controller]-[action].html",Order = 3, Name = "neptune1")]
        public ActionResult Venus(){
            var planet = _planetsService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet); //, planet
        }

        [Route("hanhtinh/{id:int}")]
        public ActionResult PlanetInfo(int id){
            var planet = _planetsService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet); //, planet
        }
    }
}
