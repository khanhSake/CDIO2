using System.Web.Mvc;
using GymWebsite.Models;
using GymWebsite.Services;

namespace GymWebsite.Controllers
{
    public class GymController : Controller
    {
        public ActionResult Index()
        {
            var gyms = DataService.GetAllGyms();
            return View(gyms);
        }

        public ActionResult Detail(string id)
        {
            var gym = DataService.GetGymById(id);
            if (gym == null)
                return HttpNotFound();
            return View(gym);
        }
        public ActionResult GymFind()
        {
            return View();
        }
        public ActionResult GymDetail()
        {
            return View();
        }
    }
}