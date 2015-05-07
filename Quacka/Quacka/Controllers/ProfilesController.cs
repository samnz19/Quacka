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

        public ActionResult Follow(string UserName = "")
        {
            if (UserName != "")
            {
                ApplicationUser userToFollow = db.Users.SingleOrDefault(u => u.UserName == UserName + "@quacka.com");
                if (userToFollow != null)
                {
                    string userId = User.Identity.GetUserId();
                    ApplicationUser currentUser = db.Users.Single(u => u.Id == userId);
                    userToFollow.Followers.Add(currentUser);
                    db.SaveChanges();
                }
            }
            return RedirectToRoute("Profile", new {userName = UserName});
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
