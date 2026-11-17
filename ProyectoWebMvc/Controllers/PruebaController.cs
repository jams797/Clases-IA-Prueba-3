using Microsoft.AspNetCore.Mvc;

namespace ProyectoWebMvc.Controllers
{
    public class PruebaController : Controller
    {
        // GET: PruebaController
        public ActionResult Index()
        {
            return View("/Views/Home/Index.cshtml");
        }

    }
}
