using System.Web.Mvc;
using GymWebsite.Models;
using GymWebsite.Services;

namespace GymWebsite.Controllers
{
    public class GymController : Controller
    {
        private readonly DataService _dataService = new DataService(); 
        public ActionResult Index()
        {
            var gyms = _dataService.GetAllGyms();
            return View(gyms);
        }
        public ActionResult Detail(string id)
        {
            var gym = _dataService.GetGymById(id);
            if (gym == null)
                return HttpNotFound();
            return View(gym);
        }
    }
}
