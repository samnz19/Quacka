using System.Linq;
using System.Web.Mvc;
using Quacka.Models;

namespace Quacka.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Show(string userName = "")
        {
            if (userName != "")
            {
                var user = db.Users.SingleOrDefault(u => u.UserName == userName + "@quacka.com");
                if (user != null)
                {
                    return View(user);
                }
            }
            return RedirectToRoute("Quacks");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
