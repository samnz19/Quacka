using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        [HttpPost]
        public ActionResult Follow(string UserName)
        {
            string currentUserId = User.Identity.GetUserId();
            if (currentUserId != null)
            {
                ApplicationUser user = db.Users.Single(u => u.Id == currentUserId);
                user.Following.Add(db.Users.Single(u => u.UserName == UserName + "@quacka.com"));
                db.SaveChanges();
            }

            return RedirectToRoute("Profile", new { userName = UserName });
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
