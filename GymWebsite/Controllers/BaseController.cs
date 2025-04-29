using System.Linq;
using System.Web.Mvc;
using GymWebsite.Data;

public abstract class BaseController : Controller
{
    protected readonly AppDbContext _context;

    public BaseController()
    {
        _context = new AppDbContext();
    }

    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);

        bool isAuth = User?.Identity?.IsAuthenticated ?? false;
        ViewBag.IsAuthenticated = isAuth;

        if (isAuth)
        {
            var u = _context.Users.FirstOrDefault(x => x.Username == User.Identity.Name);
            ViewBag.CurrentUser = u;
            ViewBag.AvatarUrl =
                string.IsNullOrEmpty(u?.ProfileImage)
                ? Url.Content("~/Content/images/default-avatar.png")
                : u.ProfileImage;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _context.Dispose();
        base.Dispose(disposing);
    }
}
